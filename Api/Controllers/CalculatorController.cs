using Contracts.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
  private readonly ILogger<CalculatorController> _logger;
  private readonly ICalculatorService _calculatorService;

  public CalculatorController(ILogger<CalculatorController> logger, ICalculatorService calculatorService)
  {
    _logger = logger;
    _calculatorService = calculatorService;
  }

  [HttpPost("sum", Name = "Sum")]
  public double Sum(double firstNumber, double secondNumber)
  {
    return _calculatorService.Sum(firstNumber, secondNumber);
  }

  [HttpPost("divide", Name = "Divide")]
  public double Divide(double firstNumber, double secondNumber)
  {
    return _calculatorService.Divide(firstNumber, secondNumber);
  }

  [HttpPost("multiply", Name = "Multiply")]
  public double Multiply(double firstNumber, double secondNumber)
  {
    return _calculatorService.Multiply(firstNumber, secondNumber);
  }

  [HttpPost("subtract", Name = "Subtract")]
  public double Subtract(double firstNumber, double secondNumber)
  {
    return _calculatorService.Subtract(firstNumber, secondNumber);
  }
}
