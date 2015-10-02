using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Fwk.HelperFunctions
{
	/// <summary>
	/// Funciones para envío de correo electrúnico.
	/// </summary>
	/// <Date>2006-04-18T00:00:00</Date>
	/// <Author>moviedo</Author>
	public class EMailFunctions
	{
		#region --[SendMail]--


		/// <summary>
		/// Envia un mensaje de correo electronico utilizando credenciales enviadas por parámetros.
		/// </summary>
		/// <param name="pFrom">Remitente.</param>
		/// <param name="pTo">Destinatario.</param>
		/// <param name="pCC">Destinatario con copia carbonica.</param>
		/// <param name="pBCC">Destinatario con copia carbonica oculta.</param>
		/// <param name="pSubject">Asunto.</param>
		/// <param name="pBody">Cuerpo del mail.</param>
		/// <param name="pBodyHtml">Indica si el contenido es html o no.</param>
		/// <param name="pAttachments">Ruta de archivos adjuntos.</param>
		/// <param name="pCredentials">Credenciales para autenticar el usuario que envía el mail.</param>
		/// <Date>2006-04-18T00:00:00</Date>
		/// <Author>moviedo</Author>
		public static void SendMail(string pFrom, string pTo, string pCC, string pBCC, string pSubject, string pBody, bool pBodyHtml, string[] pAttachments, ICredentialsByHost pCredentials)
		{
			using (MailMessage wMsg = new MailMessage(pFrom, pTo, pSubject, pBody))
			{
				SmtpClient wClient = null;

				wMsg.IsBodyHtml = pBodyHtml;

				if (pCC != null && !pCC.Equals(string.Empty))
				{
					wMsg.CC.Add(pCC);
				}

				if (pBCC != null && !pBCC.Equals(string.Empty))
				{
					wMsg.Bcc.Add(pBCC);
				}
				
				if (pAttachments != null)
				{
					foreach (string wFileName in pAttachments)
					{
						wMsg.Attachments.Add(new Attachment(wFileName));
					}
				}

				try
				{
					wClient = new SmtpClient();

					if (pCredentials != null)
					{
						wClient.Credentials = pCredentials;
					}

					wClient.Send(wMsg);
				}
				finally
				{
					wClient = null;
				}
			}
		}


		/// <summary>
		/// Envia un mensaje de correo electronico utilizando las credenciales especificadas en el .config de la aplicación.
		/// </summary>
		/// <remarks>
		/// Necesita que en el .config de la aplicación se especifique la configuración de servidor, puerto y credenciales.
		/// </remarks>
		/// <param name="pFrom">Remitente.</param>
		/// <param name="pTo">Destinatario.</param>
		/// <param name="pCC">Destinatario con copia carbonica.</param>
		/// <param name="pBCC">Destinatario con copia carbonica oculta.</param>
		/// <param name="pSubject">Asunto.</param>
		/// <param name="pBody">Cuerpo del mail.</param>
		/// <param name="pBodyHtml">Indica si el contenido es html o no.</param>
		/// <param name="pAttachments">Ruta de archivos adjuntos.</param>
		/// <example>
		/// Este ejemplo muestra como completar el .config.
		/// <code>
		/// <configuration>
		///		<system.net>
		///			<mailSettings>
		///				<smtp deliveryMethod="network">
		///				<network host="localhost" port="25" defaultCredentials="true"/>
		///				</smtp>
		///			</mailSettings>
		///		</system.net>
		/// </configuration>
		/// </code>
		/// </example>
		/// <Date>2006-04-18T00:00:00</Date>
		/// <Author>moviedo</Author>
		public static void SendMail(string pFrom, string pTo, string pCC, string pBCC, string pSubject, string pBody, bool pBodyHtml, string[] pAttachments)
		{
			SendMail(pFrom, pTo, pCC, pBCC, pSubject, pBody, pBodyHtml, pAttachments, null);
		}


		/// <summary>
		/// Envia un mensaje de correo electronico.
		/// </summary>
		/// <param name="pFrom">From.</param>
		/// <param name="pTo">To.</param>
		/// <param name="pSubject">Subject.</param>
		/// <param name="pBody">Body.</param>
		/// <param name="pBodyHtml">BodyHtml</param>
		/// <Date>2006-04-18T00:00:00</Date>
		/// <Author>moviedo</Author>
		public static void SendMail(string pFrom, string pTo, string pSubject, string pBody, bool pBodyHtml)
		{
			SendMail(pFrom, pTo, string.Empty, string.Empty, pSubject, pBody, pBodyHtml, null);
		}

		/// <summary>
		/// Envia un mensaje de correo electronico con copias.
		/// </summary>
		/// <param name="pFrom">From.</param>
		/// <param name="pTo">To.</param>
		/// <param name="pCC">CC.</param>
		/// <param name="pBCC">BCC.</param>
		/// <param name="pSubject">Subject.</param>
		/// <param name="pBody">Body.</param>
		/// <param name="pBodyHtml">BodyHtml</param>
		/// <Date>2006-04-18T00:00:00</Date>
		/// <Author>moviedo</Author>
		public static void SendMail(string pFrom, string pTo, string pCC, string pBCC, string pSubject, string pBody, bool pBodyHtml)
		{
			SendMail(pFrom, pTo, pCC, pBCC, pSubject, pBody, pBodyHtml, null);
		}


		#endregion

		#region --[MailAddressValidate]--
		/// <summary>
		/// Valida una direccion de correo electronico.
		/// </summary>
		/// <param name="pMailAddress">Direccion de correo electronico.</param>
		/// <returns>Indica si la validacion fue exitosa.</returns>
		public static bool MailAddressValidate(string pMailAddress)
		{
			return Regex.IsMatch(pMailAddress, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"); 
		}
		#endregion
	}
}
