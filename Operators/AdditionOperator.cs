namespace MathСalculatorAnin.Operators
{
    public class AdditionOperator : IOperator
    {
        public int Precedence => 1;

        public double Calculate(double left, double right) => left + right;
    }
}
