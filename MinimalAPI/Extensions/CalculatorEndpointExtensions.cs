using Contracts.Service;

namespace MinimalAPI.Extensions
{
    public static class CalculatorEndpointExtensions
    {
        public static void MapCalculatorEndpoints(this IEndpointRouteBuilder endpoints, string operation)
        {
            endpoints.MapPost($"/{operation.ToLower()}/{{first}}/{{second}}", async (
                double first,
                double second,
                CalculatorService calculatorService) =>
            {
                double result = operation switch
                {
                    "Multiply" => calculatorService.Multiply(first, second),
                    "Sum" => calculatorService.Sum(first, second),
                    "Divide" => calculatorService.Divide(first, second),
                    "Subtract" => calculatorService.Subtract(first, second),
                    _ => throw new ArgumentException("Invalid operation"),
                };

                return result > 0
              ? Results.Ok(result)
              : Results.NotFound();

            })
            .Produces<double>(StatusCodes.Status200OK)
            .Produces<double>(StatusCodes.Status404NotFound)
            .WithName($"Post{operation}")
            .WithTags(operation);
        }
    }
}
