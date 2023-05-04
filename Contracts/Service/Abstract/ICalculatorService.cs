namespace Contracts.Service.Abstract
{
    public interface ICalculatorService
    {
        double Divide(double firstNumber, double secondNumber);
        double Sum(double firstNumber, double secondNumber);
        double Subtract(double firstNumber, double secondNumber);
        double Multiply(double firstNumber, double secondNumber);
    }
}
