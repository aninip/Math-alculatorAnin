namespace MathСalculatorAnin.Operators
{
    public class MultiplicationOperator : IOperator
    {
        public int Precedence => 2;
        public string Symbol => "*";
        public double Calculate(double left, double right) => left * right;
    }
}
