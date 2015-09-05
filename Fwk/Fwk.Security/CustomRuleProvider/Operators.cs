using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace Fwk.Security
{
    /// <summary>
    /// Represents the logical negation operator 
    /// is a unary operator that negates its operand. 
    /// It returns true if and only if its operand is false.
    /// </summary>
    public class NotOperator : BooleanExpression
    {
        private BooleanExpression expression;

        /// <summary>
        /// Intializes a new instance of the 
        /// <see cref="NotOperator"/> class.
        /// </summary>
        /// <param name="expression">The operand that this
        /// operator will negate.</param>
        public NotOperator(BooleanExpression expression)
        {
            this.expression = expression;
        }

        /// <summary>
        /// Gets or sets the expression that will be negated by the
        /// current operator.
        /// </summary>
        /// <value>A <see cref="BooleanExpression"/> object.</value>
        public BooleanExpression Expression
        {
            get { return this.expression; }
        }

        /// <summary>
        /// Evaluates the current expression against the specified 
        /// <see cref="System.Security.Principal.IPrincipal"/>.
        /// </summary>
        /// <param name="principal">The <see cref="System.Security.Principal.IPrincipal"/>
        /// that the current expression will be evaluated against.</param>
        /// <returns>True or false.</returns>
        public override bool Evaluate(IPrincipal principal)
        {
            return !this.expression.Evaluate(principal);
        }
    }
    /// <summary>
    /// Represents an operator that performs a logical-OR of its
    /// contained left and right expressions, but only evaluates
    /// its second expression if the first expression evaluates to true.
    /// </summary>
    public class OrOperator : AndOperator
    {
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="OrOperator"/> class with the
        /// specified expressions.
        /// </summary>
        /// <param name="left">The first expression to evaluate.</param>
        /// <param name="right">The second expression to evaluate.</param>
        public OrOperator(
            BooleanExpression left,
            BooleanExpression right)
            : base(left, right)
        {
        }

        /// <summary>
        /// Evaluates the current expression against the specified 
        /// <see cref="System.Security.Principal.IPrincipal"/>.
        /// </summary>
        /// <param name="principal">The <see cref="System.Security.Principal.IPrincipal"/>
        /// that the current expression will be evaluated against.</param>
        /// <returns>True or false.</returns>
        public override bool Evaluate(IPrincipal principal)
        {
            return this.Left.Evaluate(principal) ||
                this.Right.Evaluate(principal);
        }
    }

    /// <summary>
    /// Represents an operator that performs a logical-AND of its
    /// contained left and right expressions, but only evaluates
    /// its second expression if the first expression evaluates to true.
    /// </summary>
    public class AndOperator : BooleanExpression
    {
        private BooleanExpression left;
        private BooleanExpression right;

        /// <summary>
        /// Initializes a new instance of the <see cref="AndOperator"/>
        /// class.
        /// </summary>
        public AndOperator()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AndOperator"/>
        /// class with the specified
        /// </summary>
        /// <param name="left">The expression that will be evaluated first.</param>
        /// <param name="right">The expression that will be evaluated last.</param>
        public AndOperator(
            BooleanExpression left,
            BooleanExpression right)
        {
            this.left = left;
            this.right = right;
        }

        /// <summary>
        /// Gets or sets the first expression that will be evaluated -
        /// the expression to the left of the operator.
        /// </summary>
        /// <value>A <see cref="BooleanExpression"/>.</value>
        public BooleanExpression Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        /// <summary>
        /// Gets or sets the second expression that will be evaluated -
        /// the expression to the right of the operator.
        /// </summary>
        /// <value>A <see cref="BooleanExpression"/>.</value>
        public BooleanExpression Right
        {
            get { return this.right; }
            set { this.right = value; }
        }

        /// <summary>
        /// Performs the logical-AND of the left
        /// and right expressions.
        /// </summary>
        /// <param name="principal">The <see cref="System.Security.Principal.IPrincipal"/>
        /// that the current expression will be evaluated against.</param>
        /// <returns>True if both the left and right expressions evaluate to true,
        /// otherwise false.</returns>
        public override bool Evaluate(IPrincipal principal)
        {
            return this.left.Evaluate(principal) &&
                this.right.Evaluate(principal);
        }
    }
}
