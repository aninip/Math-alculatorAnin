using System;

namespace MathСalculatorAnin.Operators
{
    public class PowerOperator : IOperator
    {
        public int Precedence => 3;
        public string Symbol => "^";

        public double Calculate(double left, double right) => Math.Pow(left, right);
    }
}
