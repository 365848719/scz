using System;
using System.Collections.Generic;
using System.Text;

namespace Scz.DesignPattern.Interpreter
{
    class VariableExpression : Expression
    {
        private char key;

        public VariableExpression(char key)
        {
            this.key = key;
        }

        public override double Interpret(Context context)
        {
            return context.Variable.GetValueOrDefault(this.key);
        }
    }
}
