using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Globalization;

namespace Fwk.Security
{
    /// <summary>
    /// Represents a word value such as a role
    /// name or identity name.
    /// </summary>
    public class WordExpression : BooleanExpression
    {
        private string word;

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="WordExpression"/> class.
        /// </summary>
        /// <param name="word">A string value that is 
        /// the name of an identity or role.</param>
        public WordExpression(string word)
        {
            this.word = word;
        }

        /// <summary>
        /// The string value of the word.
        /// </summary>
        /// <value>The string from the expression.</value>
        public string Value
        {
            get { return this.word; }
        }

        /// <summary>
        /// Evaluates the current expression against the specified 
        /// <see cref="System.Security.Principal.IPrincipal"/>
        /// by checking if it is in the role that matches 
        /// the Value property of the current object.
        /// </summary>
        /// <param name="principal">The <see cref="System.Security.Principal.IPrincipal"/>
        /// that the current expression will be evaluated against.</param>
        /// <returns>True if the specified principal is in the role, otherwise false.</returns>
        public override bool Evaluate(IPrincipal principal)
        {
            if (principal == null) throw new ArgumentNullException("principal");

            return principal.IsInRole(this.word);
        }

        /// <summary>
        /// Evaluates the current expression against the specified 
        /// <see cref="System.Security.Principal.IIdentity"/>
        /// by checking if its name matches 
        /// the Value property of the current object.
        /// </summary>
        /// <param name="identity">The <see cref="System.Security.Principal.IIdentity"/>
        /// that the current expression will be evaluated against.</param>
        /// <returns>True if the specified identity's name matches the value of the current expression, otherwise false.</returns>
        public virtual bool Evaluate(IIdentity identity)
        {
            if (identity == null) throw new ArgumentNullException("identity");

            string actualName = identity.Name;
            int compare = String.Compare(
                this.word,
                actualName,
                true,
                CultureInfo.InvariantCulture);
            return compare == 0;
        }
    }
}
