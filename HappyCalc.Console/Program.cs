using HappyCalc.Application.Services;
using HappyCalc.Domain.Math;

Problem problem = new();

DrawingService drawingService = new();


while(true)
{
    Console.Write("Enter expression: ");
    string line = Console.ReadLine() ?? string.Empty;    

    if (string.IsNullOrEmpty(line))
    {
        continue;
    }

    Expression newExpression = new Expression(line);
    Console.WriteLine($"Type: {newExpression.TypeDescription}");

    drawingService.DrawExpression(newExpression);
    problem.AddExpression(newExpression);
    problem.AddExpression(new Expression("x + z = 5"));
    Console.WriteLine($"Problem type: {problem.ProblemTypeDescription}");

    foreach (Expression expression in problem.Expressions)
    {
        Console.WriteLine(expression.Text);

        foreach (Expression argument in expression.AllArguments)
        {
            Console.WriteLine($"#{argument}");
        }
    }

    List<Parameter> parameters = new();
    foreach (Parameter variable in problem.Expressions[0].Variables)
    {
        Console.Write($"{variable.Name}: ");
        string value = Console.ReadLine() ?? string.Empty;
        parameters.Add(new Parameter(variable.Name, typeof(decimal), Convert.ToDecimal(value)));
    }

    object? result = problem.Expressions[0].Calculate(parameters);
    if (result != null)
    {
        Console.WriteLine($"Result: {(decimal)result}");
    }

    problem = new();
}
