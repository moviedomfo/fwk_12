using System.Globalization;

namespace Fwk.HelperFunctions
{
	/// <summary>
	/// Funciones de valores monetarios.
	/// </summary>
	/// <Date>12-05-2009</Date>
	/// <Author>moviedo</Author>
	public class MoneyFunctions
	{
		/// <summary>
		/// Devuelve el valor monetario convertido a
		/// otro tipo de cambio.
		/// </summary>
		/// <param name="pChangeValue">El valor del tipo de cambio.</param>
		/// <param name="pAmount">El monto a convertir.</param>
		/// <returns>Valor monetario.</returns>
		public static float ConversionGet(float pChangeValue, float pAmount)
		{
			return pAmount * pChangeValue;
		}

		/// <summary>
		/// Quita los puntos, 
		/// </summary>
		/// <param name="pExpresion">Expresion a evaluar.</param>
		/// <returns>Un string con el campo money formateado.</returns>
		/// <Date>12-07-2009</Date>
		/// <Author>moviedo</Author>
		public static string FormatCurrencyView(string pExpresion)
		{
			pExpresion = pExpresion.Replace(".",",");
			string[] wExpr = new string[2];
			wExpr = pExpresion.Split(',');
			if(wExpr.Length > 1)
			{
				if(wExpr[1].Length == 1)
					pExpresion += "0";
			}
			else
			{
				pExpresion += ",00";
			}
			return pExpresion;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pExpression">Expresion a formatear.</param>
		/// <returns>Texto con valor currency formateado.</returns>
		/// <Date>12-07-2009</Date>
		/// <Author>moviedo</Author>
		public static string FormatCurrency(string pExpression)
		{
			CultureInfo ciLocal = CultureInfo.CurrentCulture;

			pExpression = pExpression.Replace(ciLocal.NumberFormat.CurrencyGroupSeparator, "");
			pExpression = pExpression.Replace(ciLocal.NumberFormat.CurrencyDecimalSeparator, ".");

			return pExpression;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pExpression">Expresion a formatear.</param>
		/// <returns>Texto con valor currency formateado.</returns>
		/// <Date>12-07-2009</Date>
		/// <Author>moviedo - </Author>
		public static string FormatCurrency(double pExpression)
		{
			return FormatCurrency(pExpression.ToString());
		}
	}
}