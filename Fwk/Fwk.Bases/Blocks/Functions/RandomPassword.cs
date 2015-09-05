using System;
using System.Security.Cryptography;
using System.Text;

namespace Fwk.HelperFunctions
{
	/// <summary>
	/// 
	/// </summary>
	public class RandomPassword
	{
		// Define los valores min y max para el largo de la password.
		private static int wDefaultMinLenth  = 8;
		private static int wDefaultMaxLenth  = 10;

		// Define los caracteres soportados divididos en grupos.
		private static string wAllowedCharsLCase  = "abcdefghijklmnopqrstuvwxyz";
		private static string wAllowedCharsUCase  = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private static string wAllowedCharsNumeric= "0123456789";
		private static string wAllowedCharsSpecial= "!#$%&/()=?+-";
		/// <summary>
		/// Generar una password aleatoria.
		/// </summary>
		public static string Generate()
		{
			return Generate(wDefaultMinLenth, wDefaultMaxLenth, false, true, 0);
		}

		/// <summary>
		/// Generar una password aleatoria de una exacta longitud.
		/// </summary>
		public static string Generate(int plength)
		{
			return Generate(plength, plength, false, true, 0);
		}

		/// <summary>
		/// Generar una password aleatoria.
		/// </summary>
		/// <param name="pMinLength">Longitud Mínima</param>
		/// <param name="pMaxLength">Longitud Máxima</param>
		/// <param name="pCharsSpecial">Pernite la generación incluyendo caracteres especiales</param>
		/// <param name="pCharsNumeric">Pernite la generación incluyendo caracteres numéricos</param>
		/// <param name="pLowerUpper">Pernite la generación indicando : 0 - Indistinto, 1 - Lower, 2 - Upper</param>
		public static string Generate(int pMinLength, int   pMaxLength, bool  pCharsSpecial, bool pCharsNumeric, int pLowerUpper)
		{
			if (pMinLength <= 0 || pMaxLength <= 0 || pMinLength > pMaxLength)
				return null;

			char[][] wCharGroups = ArmarGrupoCaracteres(pCharsSpecial, pCharsNumeric, pLowerUpper);

			int[] wCharsLeftInGroup = new int[wCharGroups.Length];

			for (int i=0; i<wCharsLeftInGroup.Length; i++)
				wCharsLeftInGroup[i] = wCharGroups[i].Length;

			int[] wLeftGroupsOrder = new int[wCharGroups.Length];

			for (int i=0; i<wLeftGroupsOrder.Length; i++)
				wLeftGroupsOrder[i] = i;

			byte[] wRandomBytes = new byte[wCharGroups.Length];

			// Genera un random bytes.
			RNGCryptoServiceProvider wRNG = new RNGCryptoServiceProvider();
			wRNG.GetBytes(wRandomBytes);

			// Convierte byte[] en un Int32.
			int wSeed = 0;
			if(wCharGroups.Length == 4)
			{
				wSeed = (wRandomBytes[0] & 0x7f) << 24 |
					wRandomBytes[1]         << 16 |
					wRandomBytes[2]         <<  8 |
					wRandomBytes[3];
			}
			else if(wCharGroups.Length == 3)
			{
				wSeed = (wRandomBytes[0] & 0x7f) << 24 |
					wRandomBytes[1]         << 16 |
					wRandomBytes[2]         <<  8;
			}
			else if(wCharGroups.Length == 2)
			{
				wSeed = (wRandomBytes[0] & 0x7f) << 24 |
					wRandomBytes[1]         << 16;
			}
			else if(wCharGroups.Length == 1)
			{
				wSeed = (wRandomBytes[0] & 0x7f);
			}

			Random  wRandom  = new Random(wSeed);

			char[] wPassword = null;

			if (pMinLength < pMaxLength)
				wPassword = new char[wRandom.Next(pMinLength, pMaxLength+1)];
			else
				wPassword = new char[pMinLength];

			int wNextCharIdx;
			int wNextGroupIdx;
			int wNextwLeftGroupsOrderIdx;
			int wLastCharIdx;
			int wLastLeftGroupsOrderIdx = wLeftGroupsOrder.Length - 1;
        
			for (int i=0; i<wPassword.Length; i++)
			{
				if (wLastLeftGroupsOrderIdx == 0)
					wNextwLeftGroupsOrderIdx = 0;
				else
					wNextwLeftGroupsOrderIdx = wRandom.Next(0, wLastLeftGroupsOrderIdx);

				wNextGroupIdx = wLeftGroupsOrder[wNextwLeftGroupsOrderIdx];
				wLastCharIdx = wCharsLeftInGroup[wNextGroupIdx] - 1;
				if (wLastCharIdx == 0)
					wNextCharIdx = 0;
				else
					wNextCharIdx = wRandom.Next(0, wLastCharIdx+1);

				wPassword[i] = wCharGroups[wNextGroupIdx][wNextCharIdx];
				if (wLastCharIdx == 0)
					wCharsLeftInGroup[wNextGroupIdx] = wCharGroups[wNextGroupIdx].Length;
				else
				{
					if (wLastCharIdx != wNextCharIdx)
					{
						char wTemp = wCharGroups[wNextGroupIdx][wLastCharIdx];
						wCharGroups[wNextGroupIdx][wLastCharIdx] = wCharGroups[wNextGroupIdx][wNextCharIdx];
						wCharGroups[wNextGroupIdx][wNextCharIdx] = wTemp;
					}
					wCharsLeftInGroup[wNextGroupIdx]--;
				}

				if (wLastLeftGroupsOrderIdx == 0)
					wLastLeftGroupsOrderIdx = wLeftGroupsOrder.Length - 1;
				else
				{
					if (wLastLeftGroupsOrderIdx != wNextwLeftGroupsOrderIdx)
					{
						int wTemp = wLeftGroupsOrder[wLastLeftGroupsOrderIdx];
						wLeftGroupsOrder[wLastLeftGroupsOrderIdx] = wLeftGroupsOrder[wNextwLeftGroupsOrderIdx];
						wLeftGroupsOrder[wNextwLeftGroupsOrderIdx] = wTemp;
					}
					wLastLeftGroupsOrderIdx--;
				}
			}

			return new string(wPassword);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pPassword"></param>
		/// <returns></returns>
		public static string ComputeHash(string pPassword)
		{
			ASCIIEncoding wEncoder = new ASCIIEncoding();
			Byte[] wSecretBytes = wEncoder.GetBytes(pPassword);
			
			Byte[] wToHash = new Byte[wSecretBytes.Length];
			Array.Copy(wSecretBytes, 0, wToHash, 0, wSecretBytes.Length);

			SHA1 wSha1 = SHA1.Create();
			Byte[] wComputedHash = wSha1.ComputeHash(wToHash);

			return wEncoder.GetString(wComputedHash);
		}

		/// <summary>
		/// Agrupa caracteres por tipo.
		/// </summary>
		/// <param name="pCharsSpecial">Pernite la generación incluyendo caracteres especiales</param>
		/// <param name="pCharsNumeric">Pernite la generación incluyendo caracteres numéricos</param>
		/// <param name="pLowerUpper">Pernite la generación indicando : 0 - Indistinto, 1 - Lower, 2 - Upper</param>
		private static char[][] ArmarGrupoCaracteres ( bool pCharsSpecial , bool pCharsNumeric , int pLowerUpper )
		{
			char[][] wResult = null;
			if(pCharsSpecial && pCharsNumeric && pLowerUpper==0)
			{
				char[][] wCharGroups = new char[][]
			{
				wAllowedCharsLCase.ToCharArray(),
				wAllowedCharsUCase.ToCharArray(),
				wAllowedCharsNumeric.ToCharArray(),
				wAllowedCharsSpecial.ToCharArray()
			};
				wResult = wCharGroups;
			}
			else if(pCharsSpecial && pCharsNumeric && pLowerUpper==1)
			{
				char[][] wCharGroups = new char[][]
			{
				wAllowedCharsLCase.ToCharArray(),
				wAllowedCharsNumeric.ToCharArray(),
				wAllowedCharsSpecial.ToCharArray()
			};
				wResult = wCharGroups;
			}
			else if(pCharsSpecial && pCharsNumeric && pLowerUpper==2)
			{
				char[][] wCharGroups = new char[][]
			{
				wAllowedCharsUCase.ToCharArray(),
				wAllowedCharsNumeric.ToCharArray(),
				wAllowedCharsSpecial.ToCharArray()
			};
				wResult = wCharGroups;
			}
			else if(pCharsSpecial && pLowerUpper==0)
			{
				char[][] wCharGroups = new char[][]
			{
				wAllowedCharsLCase.ToCharArray(),
				wAllowedCharsUCase.ToCharArray(),
				wAllowedCharsSpecial.ToCharArray()
			};
				wResult = wCharGroups;
			}
			if(pCharsNumeric && pLowerUpper==0)
			{
				char[][] wCharGroups = new char[][]
			{
				wAllowedCharsLCase.ToCharArray(),
				wAllowedCharsUCase.ToCharArray(),
				wAllowedCharsNumeric.ToCharArray()
			};
				wResult = wCharGroups;
			}
			if(pCharsSpecial && pLowerUpper==1)
			{
				char[][] wCharGroups = new char[][]
			{
				wAllowedCharsLCase.ToCharArray(),
				wAllowedCharsSpecial.ToCharArray()
			};
				wResult = wCharGroups;
			}
			if(pCharsNumeric && pLowerUpper==1)
			{
				char[][] wCharGroups = new char[][]
			{
				wAllowedCharsLCase.ToCharArray(),
				wAllowedCharsNumeric.ToCharArray()
			};
				wResult = wCharGroups;
			}
			if(pCharsSpecial && pLowerUpper==2)
			{
				char[][] wCharGroups = new char[][]
			{
				wAllowedCharsUCase.ToCharArray(),
				wAllowedCharsSpecial.ToCharArray()
			};
				wResult = wCharGroups;
			}
			if(pCharsNumeric && pLowerUpper==2)
			{
				char[][] wCharGroups = new char[][]
			{
				wAllowedCharsUCase.ToCharArray(),
				wAllowedCharsNumeric.ToCharArray()
			};
				wResult = wCharGroups;
			}
			else if(pLowerUpper==0)
			{
				char[][] wCharGroups = new char[][]
			{
				wAllowedCharsLCase.ToCharArray(),
				wAllowedCharsUCase.ToCharArray()
			};
				wResult = wCharGroups;
			}
			else if(pLowerUpper==1)
			{
				char[][] wCharGroups = new char[][]
			{
				wAllowedCharsLCase.ToCharArray()
			};
				wResult = wCharGroups;
			}
			else if(pLowerUpper==2)
			{
				char[][] wCharGroups = new char[][]
			{
				wAllowedCharsUCase.ToCharArray()
			};
				wResult = wCharGroups;
			}
			return wResult;
		}
	}
}