using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Fwk.Exceptions;
using VivaldiSite.DAC;


namespace VivaldiSite.Security
{
    public partial class PasswordResset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Msg.Text = string.Empty;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string userNane = Membership.GetUserNameByEmail(txtEmail.Text.Trim());

                if (string.IsNullOrEmpty(userNane))
                {
                    Msg.Text = "No se encuentra registrado un usuario con esa direccion de e-mail en nuestras bases de datos.-";
                }

                
                

                //if (Membership.RequiresQuestionAndAnswer)
                //{
                //    newUser.ChangePasswordQuestionAndAnswer(txtPasswordTextbox.Text,
                //                                            txtPasswordQuestionTextbox.Text,
                //                                            txtPasswordAnswerTextbox.Text);
                //}
                //Request.ApplicationPath.Replace("//", "/"),
                string ruta = System.IO.Path.GetDirectoryName(Request.PhysicalPath);
                string file = System.IO.Path.Combine(ruta, "Email_Forgot_Password.html");
                string txt = Fwk.HelperFunctions.FileFunctions.OpenTextFile(file);

                //arreglar
                //CommonDAC.SendMail("Registracion de socio al sitio web de Health", string.Format(txt, userNane), "support_noreply@Health.com", txtEmail.Text.Trim());
                //Helper.SendMail("Solicitud de reseteo de clave de socio al sitio web de Health", string.Format(txt, userNane), "support_noreply@Health.com", "klx650_98@yahoo.com");
                Response.Redirect("Login.aspx");
            }
           
            catch (HttpException ex2)
            {
                Msg.Text = ex2.Message;
            }
            catch (TechnicalException tex)
            {
                Msg.Text = tex.Message;
            }
        }
    }
}