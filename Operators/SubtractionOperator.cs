namespace MathСalculatorAnin.Operators
{
    public class SubtractionOperator : IOperator
    {
        public int Precedence => 1;
        public string Symbol => "-";
        public double Calculate(double left, double right) => left - right;
    }
}
