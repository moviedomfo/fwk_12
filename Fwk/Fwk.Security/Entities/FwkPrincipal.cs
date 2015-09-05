using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Security.Principal;

namespace Fwk.Security.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class FwkPrincipal : IPrincipal
    {
        private IIdentity _identity;
        private string[] _roles;
        /// <summary>
        /// 
        /// </summary>
        public FwkPrincipal(IIdentity identity, string[] roles)
        {
            _identity = identity;

            _roles = new string[roles.Length];
            roles.CopyTo(_roles, 0);
            Array.Sort(_roles);
        }
        /// <summary>
        /// 
        /// </summary>
        public IIdentity Identity
        {
            get { return _identity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsInRole(string role)
        { return Array.BinarySearch(_roles, role) >= 0 ? true : false; }

      
    }
}