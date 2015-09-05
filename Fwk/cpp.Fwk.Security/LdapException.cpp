#include "stdafx.h"

using namespace System;



namespace Fwk {
namespace Security {


	public ref class LdapException : System::Exception
	{
	public:
		LdapException() : Exception() { }
		LdapException(String^ pMessage) : Exception(pMessage) { }
		LdapException(char* pMessage) : Exception(gcnew System::String(pMessage)) { }
	};

	public ref class LdapAuthenticationException : LdapException
	{
	public:
		LdapAuthenticationException() : LdapException() { }
		LdapAuthenticationException(String^ pMessage) : LdapException(pMessage) { }
		LdapAuthenticationException(char* pMessage) : LdapException(gcnew System::String(pMessage)) { }
	};


}
}
