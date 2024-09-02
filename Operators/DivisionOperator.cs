using System;

namespace MathСalculatorAnin.Operators
{
    public class DivisionOperator : IOperator
    {
        public int Precedence => 2;

        public double Calculate(double left, double right)
        {
            if (right == 0)
            {
                throw new DivideByZeroException("Попытка деления на ноль.");
            }
            return left / right;
        }
    }
}
