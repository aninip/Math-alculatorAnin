namespace MathСalculatorAnin.Operators
{
    public interface IOperator
    {
        int Precedence { get; }
        double Calculate(double left, double right);
        string Symbol { get; }
    }
}
