// Archivo DLL principal.

#include "LdapEntry.h"
#include "stdafx.h"

#include <windows.h>
#include <Winldap.h>
#include <winber.h>
#include <rpcdce.h>
#include <stdio.h>
#include <atlstr.h>

#include "LdapException.cpp"

#using <mscorlib.dll>
using namespace System;
using namespace System::Text;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;




namespace Fwk {
	namespace Security {
	//public ref class LdapEntryValueList : array<String^, 1> { };

	public ref class LdapEntry : Dictionary<String^, array<String^, 1>^> { };

	public ref class LdapEntryList : List<LdapEntry^> { };

	public ref class LdapWrapper
	{

	public:
		property String^ HostName
		{
			String^ get() { return gcnew String(_HostName); }
		};
		property String ^ DomainDN
		{
			String^ get() { return gcnew String(_DomainDN); }
		};

		property String ^ UserName
		{
			String^ get() { return gcnew String(_UserName); }
		}
		property int LdapSslCipherStrenght
		{
			int get() { return _LdapSslCipherStrength; }
		}

		static const int MAX_ENTRIES_RESULT = 100;
		static const int MAX_ATTR_RESULT = 10;

	private:
		PCHAR _HostName;
		PCHAR _DomainDN;
		PCHAR _UserName;
		LDAP* _LdapConnection;
		int _LdapSslCipherStrength;

		void LdapInit()
		{
			_LdapConnection = NULL;
			_LdapConnection = ldap_init(_HostName, LDAP_PORT);

			if (_LdapConnection == NULL)
			{
				char wErrorMsg [50];
				sprintf(wErrorMsg, "ldap_init failed with 0x%x.", LdapGetLastError());
				throw wErrorMsg;
			}
		}

		void LdapSSLInit()
		{
			char wErrorMsg [50];

			_LdapConnection = NULL;
			_LdapConnection = ldap_sslinit(_HostName, LDAP_SSL_PORT, 1);

			if (_LdapConnection == NULL)
			{
				sprintf(wErrorMsg, "ldap_sslinit failed with 0x%x.", LdapGetLastError());
				throw wErrorMsg;
			}
		}

		void LdapSetVersion(ULONG version)
		{
			ULONG lRtn = 0;
			char wErrorMsg [50];

			lRtn = ldap_set_option(
				_LdapConnection,           // Session handle
				LDAP_OPT_PROTOCOL_VERSION, // Option
				(void*) &version);         // Option value

			if(lRtn != LDAP_SUCCESS)
			{
				sprintf(wErrorMsg, "ldap_set_option opt:LDAP_OPT_PROTOCOL_VERSION, value:LDAP_VERSION3 error:%0lX", lRtn);
				throw wErrorMsg;
			}
		}


		void LdapSetSSLOptions()
		{
			ULONG lRtn;
			LONG lv = 0;
			char wErrorMsg [50];

			//printf("Checking if SSL is enabled");
			lRtn = ldap_get_option(
				_LdapConnection,
				LDAP_OPT_SSL,
				(void*)&lv);
			if(lRtn != LDAP_SUCCESS)
			{
				sprintf(wErrorMsg, "ldap_get_option LDAP_OPT_SSL error:%0lX", lRtn);
				throw wErrorMsg;
			}

			if ((void*)lv == LDAP_OPT_ON)
			{
				//printf("SSL is not enabled");
				//printf("SSL not enabled. SSL being enabled...");
				lRtn = ldap_set_option(
					_LdapConnection,
					LDAP_OPT_SSL,
					LDAP_OPT_ON);
				if(lRtn != LDAP_SUCCESS)
				{
					sprintf(wErrorMsg, "ldap_set_option opt:LDAP_OPT_SSL value:LDAP_OPT_ON error:%0lX", lRtn);
					throw wErrorMsg;
				}
			}
		}

		void LdapConnect()
		{
			ULONG lRtn;
			lRtn = ldap_connect(_LdapConnection, NULL);
			char wErrorMsg [50];

			if(lRtn != LDAP_SUCCESS)
			{
				sprintf(wErrorMsg, "ldap_connect failed with 0x%x.", lRtn);
				throw wErrorMsg;
			}
		}
		void LdapBind(PCHAR pPassowrd)
		{
			ULONG lRtn;
			SEC_WINNT_AUTH_IDENTITY secIdent;
			char wErrorMsg [50];

			secIdent.User = (unsigned char*)_UserName;
			secIdent.UserLength = strlen(_UserName);
			secIdent.Password = (unsigned char*)pPassowrd;
			secIdent.PasswordLength = strlen(pPassowrd);
			secIdent.Domain = (unsigned char*)_HostName;
			secIdent.DomainLength = strlen(_HostName);
			secIdent.Flags = SEC_WINNT_AUTH_IDENTITY_ANSI;

			lRtn = ldap_bind_s(
				_LdapConnection,		// Session Handle
				_DomainDN,				// Domain DN
				(PCHAR)&secIdent,		// Credential structure
				LDAP_AUTH_NEGOTIATE);	// Auth mode
			if(lRtn == LDAP_SUCCESS)
			{
				secIdent.Password = NULL;		// Remove password pointer
				pPassowrd = NULL;				// Remove password pointer
			}
			else
			{
				sprintf(wErrorMsg, "ldap_bind_s failed with 0x%x.", lRtn);
				//throw _ErrorMsg;
				throw gcnew Fwk::Security::LdapAuthenticationException(gcnew String(wErrorMsg));
			}
		}
		int GetLdapSslCipherStrenght()
		{
			ULONG lRtn;
			SecPkgContext_ConnectionInfo sslInfo;
			char wErrorMsg [50];

			lRtn = ldap_get_option(
				_LdapConnection,
				LDAP_OPT_SSL_INFO,
				&sslInfo);
			if(lRtn != LDAP_SUCCESS)
			{
				sprintf(wErrorMsg, "ldap_get_option LDAP_OPT_SSL error:%0lX", lRtn);
				throw wErrorMsg;
			}
			return (int)sslInfo.dwCipherStrength;
		}


		void encodePwd(String^ pPlainPwd, PCHAR& wUnicodePwd, int& oLenght) 
		{

			Encoding^ wUnicode = Encoding::Unicode;
			cli::array<Byte,1>^ wUnicodeBytes = wUnicode->GetBytes(pPlainPwd);
			oLenght = wUnicodeBytes->Length+4;

			wUnicodePwd = new char[wUnicodeBytes->Length+4]; // largo de la cadena + las comillas
			wUnicodePwd[0] = 0x022; // comillas
			wUnicodePwd[1] = 0x000; // null
			for ( int i = 0; i < wUnicodeBytes->Length; i++ ) {
				 wUnicodePwd[i+2] = wUnicodeBytes[i];
			}
			wUnicodePwd[wUnicodeBytes->Length+2] = 0x022; // comillas
			wUnicodePwd[wUnicodeBytes->Length+3] = 0x000; // null
		}

	public:
		Boolean Bind(String ^ pHostName, String ^ pDomainDN, String ^ pUserName, String ^ pPassowrd, Boolean pSecure) 
		{
			try 
			{
				_HostName = (PCHAR)(void*)Marshal::StringToHGlobalAnsi(pHostName);
				_DomainDN = (PCHAR)(void*)Marshal::StringToHGlobalAnsi(pDomainDN);
				_UserName = (PCHAR)(void*)Marshal::StringToHGlobalAnsi(pUserName);

				//-------------------------------------------------------
				// Init 
				//-------------------------------------------------------
				if (!pSecure)
					LdapInit();
				else
					LdapSSLInit();

				//-------------------------------------------------------
				// Set session options.
				//-------------------------------------------------------
				LdapSetVersion(LDAP_VERSION3); // Set the version to 3.0 (default is 2.0).
				if (pSecure) 
					LdapSetSSLOptions(); // Checking if SSL is enabled, if not, then enable it

				//--------------------------------------------------------
				// Connect to the server.
				//--------------------------------------------------------
				LdapConnect(); // establish TCP/IP connection

				//--------------------------------------------------------
				// Bind with User credentials.
				//--------------------------------------------------------
				LdapBind((PCHAR)(void*)Marshal::StringToHGlobalAnsi(pPassowrd)); // authentication currenct connection

				//--------------------------------------------------------
				// Retrieve the SSL cipher strenght
				//--------------------------------------------------------
				if (pSecure) 
					_LdapSslCipherStrength = GetLdapSslCipherStrenght(); // by operation like password reset, it must by 128 bits at lease

				// OK
				return true;
			} 
			catch (PCHAR str) 
			{
				UnBind();
				throw gcnew Fwk::Security::LdapException(str);
			}
			return false;
		}

		Boolean SetPassword(String^ pUserDN, String^ pPlainPwd, Boolean pForceChangeOnFirstLogon, Boolean pUnlockAccount)
		{

			int wAttrMax = 1;
			if (!String::IsNullOrEmpty(pPlainPwd))
				wAttrMax++;
			if (pForceChangeOnFirstLogon == true)
				wAttrMax++;
			if (pUnlockAccount == true)
				wAttrMax++;

			int wAttrCount = 0;
			ULONG lRtn = 0;
			LDAPMod *wAttrs[10];

			PCHAR wUserDN;
			char wErrorMsg [50];

			try
			{
				wUserDN = (PCHAR)(void*)Marshal::StringToHGlobalAnsi(pUserDN);

				if (!String::IsNullOrEmpty(pPlainPwd))
				{
					LDAPMod wPwdAttr;
					berval *wPwdArrayValues[2];
					berval wPwdValue;
					PCHAR wUnicodePwd;
					int oLenght;

					// codifica el pwd en unicode y agrega comillas al adelante y atrás
					encodePwd(pPlainPwd, wUnicodePwd, oLenght);

					wPwdValue.bv_len = oLenght;
					wPwdValue.bv_val = wUnicodePwd;

					wPwdArrayValues[0] = &wPwdValue;
					wPwdArrayValues[1]= NULL;

					wPwdAttr.mod_op = LDAP_MOD_REPLACE | LDAP_MOD_BVALUES;
					wPwdAttr.mod_type = "unicodePwd";
					wPwdAttr.mod_vals.modv_bvals = wPwdArrayValues;
					
					wAttrs[wAttrCount] = &wPwdAttr;
					wAttrCount++;
				}

				if (pForceChangeOnFirstLogon == true) 
				{
					LDAPMod wForceChangeAttr;
					berval* wForceChangeValues[2];
					berval wForceChangeValue;

					wForceChangeValue.bv_len = 1;
					wForceChangeValue.bv_val = "0";

					wForceChangeValues[0] = &wForceChangeValue;
					wForceChangeValues[1] = NULL;

					wForceChangeAttr.mod_op = LDAP_MOD_REPLACE | LDAP_MOD_BVALUES;
					wForceChangeAttr.mod_type = "pwdLastSet";
					wForceChangeAttr.mod_vals.modv_bvals = wForceChangeValues;

					wAttrs[wAttrCount] = &wForceChangeAttr;
					wAttrCount++;
				}

				if (pUnlockAccount == true)
				{
					LDAPMod wUnlockAttr;
					berval* wUnlockValues[2];
					berval wUnlockVal;

					wUnlockVal.bv_len = 1;
					wUnlockVal.bv_val = "0";

					wUnlockValues[0] = &wUnlockVal;
					wUnlockValues[1] = NULL;

					wUnlockAttr.mod_op = LDAP_MOD_REPLACE | LDAP_MOD_BVALUES;
					wUnlockAttr.mod_type = "LockOutTime";
					wUnlockAttr.mod_vals.modv_bvals = wUnlockValues;

					wAttrs[wAttrCount] = &wUnlockAttr;
					wAttrCount++;
				}

				wAttrs[wAttrCount] = NULL;

				lRtn = ldap_modify_s(
							_LdapConnection,    // Session Handle
							wUserDN,			// Object DN
							wAttrs);			// Data
				if(lRtn != LDAP_SUCCESS)
				{
					sprintf(wErrorMsg, "ldap_modidy_s failed with 0x%lx.", lRtn);
					throw wErrorMsg;
				}

				// OK
				return true;
			}
			catch (PCHAR str)
			{
				throw gcnew Fwk::Security::LdapException(str);
			}
			return false;
		}


		void UnBind()
		{
			ldap_unbind_s(_LdapConnection);
			_LdapConnection = NULL;
		}

		int Search (String ^ pFilter, array<String^,1>^ pAttributes, LdapEntryList^ pResults) 
		{

			array<String^, 1>^ wEntryValues;
			LdapEntry^ wLdapEntry;
			LdapEntryList^ wLdapEntryList;

			PCHAR wAttributes[MAX_ATTR_RESULT];
			LDAPMessage* wSearchResult;
			ULONG wNumberOfEntries;
			PCHAR* wValue = NULL;
			BerElement* pBer = NULL;
			char wErrorMsg [50];
			PCHAR wFilter;

			if (pAttributes->Length > 0) {
				for (int i=0; i<pAttributes->Length; i++)
				{
					wAttributes[i] = (PCHAR)(void*)Marshal::StringToHGlobalAnsi(pAttributes[i]);
				}
				wAttributes[pAttributes->Length] = NULL;
			}
			else 
			{
				// trae el nombre, porque si va vacío, trae un juego por defecto
				//wAttributes[0] = "name";
				wAttributes[0] = NULL;
				//int wAttributes = NULL;
			}

			try
			{

				if (_LdapConnection == NULL)
				{
					throw "No se estableció una conexión válida";
				}

				ULONG wNumReturns = MAX_ENTRIES_RESULT;
				ULONG lRtn = 0;

				wFilter = (PCHAR)(void*)Marshal::StringToHGlobalAnsi(pFilter);

				//----------------------------------------------------------
				// Set the limit on the number of entries returned.
				//----------------------------------------------------------
				lRtn = ldap_set_option(
								_LdapConnection,       // Session handle
								LDAP_OPT_SIZELIMIT,    // Option
								(void*) &wNumReturns);  // Option value

				if(lRtn != LDAP_SUCCESS)
				{
					sprintf(wErrorMsg, "ldap_set_option LDAP_OPT_SIZELIMIT failed error:%0lX", lRtn);
					throw wErrorMsg;
				}

				//----------------------------------------------------------
				// Perform a synchronous search 
				//----------------------------------------------------------
				ULONG errorCode = LDAP_SUCCESS;
			    
				errorCode = ldap_search_s(
								_LdapConnection,			// Session handle
								(PCHAR)_DomainDN,			// DN to start search
								LDAP_SCOPE_SUBTREE,			// Scope
								wFilter,					// Filter
								wAttributes,				// Retrieve list of attributes
								0,							// Get both attributes and values
								&wSearchResult);			// [out] Search results
			    
				if (errorCode != LDAP_SUCCESS && errorCode != LDAP_REFERRAL)
				{
					sprintf(wErrorMsg, "ldap_search_s failed with error:%0lX", errorCode);
					throw wErrorMsg;
				}


				//----------------------------------------------------------
				// Get the number of entries returned.
				//----------------------------------------------------------
			    
				wNumberOfEntries = ldap_count_entries(
									_LdapConnection,    // Session handle
									wSearchResult);     // Search result

				// TODO: No se como detectar si no trajo resultados porque no hay o porque dio error

				//if(wNumberOfEntries == NULL)
				//{
				//	sprintf(_ErrorMsg, "ldap_count_entries failed error:%0lX", LdapGetLastError());
				//	throw _ErrorMsg;
				//}
				//printf("The number of entries is: %d ", numberOfEntries);
			    

				//----------------------------------------------------------
				// Loop through the search entries, get, and output the
				// requested list of attributes and values.
				//----------------------------------------------------------
				LDAPMessage* wEntry = NULL;
				PCHAR wEntryDN = NULL;
				ULONG iCnt = 0;
				ULONG iACnt = 0;
				PCHAR sMsg;
				PCHAR wAttribute = NULL;
				ULONG iValue = 0;

				for( iCnt=0; iCnt < wNumberOfEntries; iCnt++ )
				{

					// Get the first/next entry.
					if( !iCnt )
						wEntry = ldap_first_entry(_LdapConnection, wSearchResult);
					else
						wEntry = ldap_next_entry(_LdapConnection, wEntry);
			        
					// Output a status message.
					if( wEntry == NULL )
					{
						sMsg = (!iCnt ? "ldap_first_entry" : "ldap_next_entry");
						sprintf(wErrorMsg, "%s failed with error:%0lX", LdapGetLastError());
						throw wErrorMsg;
					}
			                
					// Get the firt attribute name.
					wAttribute = ldap_first_attribute(
								  _LdapConnection,   // Session handle
								  wEntry,            // Current entry
								  &pBer);            // [out] Current BerElement
			        
					iACnt = 0;


					// Output the attribute names for the current object
					// and output values.
					wLdapEntry = gcnew LdapEntry();
					while(wAttribute != NULL)
					{
						// Output the attribute name.
						//printf("     ATTR: %s",pAttribute);
			            
						// Get the string values.

						wValue = ldap_get_values(
									  _LdapConnection,  // Session Handle
									  wEntry,           // Current entry
									  wAttribute);      // Current attribute

						if (wValue != NULL) 
						{
							iValue = ldap_count_values(wValue);
							wEntryValues = gcnew array<String^, 1>(iValue);
							for ( int i = 0; i < iValue; i++ ) 
							{
								wEntryValues[i] = gcnew String(wValue[i]);
							}
							wLdapEntry->Add(gcnew String(wAttribute), wEntryValues);
						}

						// Free memory.
						if(wValue != NULL)  
							ldap_value_free(wValue);
						wValue = NULL;
						ldap_memfree(wAttribute);
			            
						// Get next attribute name.
						wAttribute = ldap_next_attribute(
										_LdapConnection,   // Session Handle
										wEntry,            // Current entry
										pBer);             // Current BerElement
						iACnt++;
					}
					pResults->Add(wLdapEntry);
				}
			}
			catch (char * str) 
			{
				throw gcnew Fwk::Security::LdapException(str);
			}
			finally
			{
				//ldap_unbind_s(_LdapConnection);
				if (wSearchResult != NULL)
					ldap_msgfree(wSearchResult);
				wSearchResult = NULL;

				if (wValue != NULL)
					ldap_value_free(wValue);
				wValue = NULL;

				if( pBer != NULL )
					ber_free(pBer,0);
				pBer = NULL;
			}
			return wNumberOfEntries;

		}

	};
}
}