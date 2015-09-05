using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace Fwk.Security
{
    /// <summary>
    /// Represents an expression that evaluates to true
    /// for any specified principal.
    /// </summary>
    public class AnyExpression : WordExpression
    {
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="AnyExpression"/> class.
        /// </summary>
        public AnyExpression()
            : base("?")
        {
        }

        /// <summary>
        /// Evaluates the specified principal and returns
        /// true if the principal is not null.
        /// </summary>
        /// <param name="principal">The <see cref="System.Security.Principal.IPrincipal"/>
        /// that the current expression will be evaluated against.</param>
        /// <returns><strong>True</strong> if the principal
        /// is not null, otherwise <strong>false</strong>.</returns>
        public override bool Evaluate(IPrincipal principal)
        {
            if (principal != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Evaluates the specified 
        /// <see cref="System.Security.Principal.IIdentity"/>.
        /// </summary>
        /// <param name="identity">The <see cref="System.Security.Principal.IIdentity"/>
        /// that the current expression will be evaluated against.</param>
        /// <returns><strong>True</strong> if the identity not null, 
        /// otherwise <strong>false</strong>.</returns>
        public override bool Evaluate(IIdentity identity)
        {
            if (identity != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
