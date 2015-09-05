using System;
using System.Collections;

namespace Fwk.HelperFunctions
{
	/// <summary>
	/// Funciones matemáticas.
	/// </summary>
	/// <Date>17-01-2005</Date>
	/// <Author>moviedo</Author>
	public class MathFunctions
	{
		/// <summary>
		/// Calcula el Maximo Comun Divisor de una lista de valores enteros,
		/// aplicando propiedad asociativa si hay más de dos valores.
		/// </summary>
		/// <returns>Numero entero Maximo Comun Divisor</returns>
		/// <Date>17-01-2005</Date>
		/// <Author>moviedo</Author>
		public static int MaxCommonDivisor (ArrayList pValues)
		{
			int wValorA = 0;
			int wValorB = 0;
			int wResto = 0;
			int wReturn = 0;

			for (int i = 0; i <= pValues.Count - 1; i++)
			{
				if (i == 0)
					wReturn = Math.Abs((int) pValues[i]);
				else
				{
					if (wReturn > Math.Abs((int) pValues[i]))
					{
						wValorA = wReturn;
						wValorB = Math.Abs((int) pValues[i]);
					}
					else
					{
						wValorA = Math.Abs((int) pValues[i]);
						wValorB = wReturn;
					}

					while (wValorB > 0)
					{
						wResto = wValorA % wValorB;
						wValorA = wValorB;
						wValorB = wResto;
					}

					wReturn = wValorA;

				}

			}

			return wReturn;

		}

		/// <summary>
		/// Determina si pMultiplo es multiplo de pFactor
		/// ej:IsFactor (16,4) = true 
		/// </summary>
		/// <param name="pFactor">Es el factor </param>
		/// <param name="pMultiplo">Valor sobre el cual se quiere saber si es Factor</param>
		/// <returns>boolean </returns>
		public static bool IsFactor(decimal pMultiplo,decimal pFactor)
		{
			try
			{
				decimal wResto = pFactor % pMultiplo;
				if (wResto == 0)
					return true;
				else
					return false;
			}
			catch
			{
				//retorno false ya que si se da una DivideByZeroException o una OverflowException
				//se trataria de que pMultiplo no es Factor de pFactor
				return false;

			}
		}
	}
}