using System;
using System.Collections.Generic;
using System.Text;

namespace Scz.DesignPattern.Interpreter
{
    public abstract class OperatorExpression : Expression
    {
        protected Expression left;
        protected Expression right;

        public OperatorExpression(Expression left,Expression right)
        {
            this.left = left;
            this.right = right;
        }

    }
}
