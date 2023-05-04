using Contracts.Service.Abstract;

namespace Contracts.Service
{
    public class CalculatorService : ICalculatorService
  {
    public double Divide(double firstNumber, double secondNumber)
    {
      return firstNumber / secondNumber;
    }

    public double Multiply(double firstNumber, double secondNumber)
    {
      return (firstNumber * secondNumber);
    }

    public double Subtract(double firstNumber, double secondNumber)
    {
      return secondNumber - firstNumber;
    }

    public double Sum(double firstNumber, double secondNumber)
    {
       return firstNumber + secondNumber;
    }
  }
}
