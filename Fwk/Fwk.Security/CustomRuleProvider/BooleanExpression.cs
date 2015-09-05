using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace Fwk.Security
{
    /// <summary>
    /// Represents an operator, operand or expression
    /// that results in one of two values - true or false.
    /// </summary>
    public abstract class BooleanExpression
    {
        /// <summary>
        /// Evaluates the current expression against the specified 
        /// <see cref="System.Security.Principal.IPrincipal"/>.
        /// </summary>
        /// <param name="principal">The <see cref="System.Security.Principal.IPrincipal"/>
        /// that the current expression will be evaluated against.</param>
        /// <returns>True or false.</returns>
        public abstract bool Evaluate(IPrincipal principal);
    }
}
