using System;
using System.Linq;

namespace Calculator
{
  public class CalculatorService
  {
    private readonly char[] operations = { '+', '-' };
    private readonly char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    public string[] VariablesList { get; private set; }
    public string[] OperationsList { get; private set; }

    public int Solve(string expression)
    {
      this.Analyze(expression);

      var index = 0;
      int result = int.Parse(this.VariablesList[index]);
      int operand2 = 0;

      foreach (var operation in this.OperationsList)
      {
        operand2 = int.Parse(this.VariablesList[++index]);
        switch (operation)
        {
          case "+":
            {
              result += operand2;
              break;
            }
          case "-":
            {
              result -= operand2;
              break;
            }
        }
      }

      return result;
    }

    protected void Analyze(string expression)
    {
      if (string.IsNullOrWhiteSpace(expression))
      {
        throw new ArgumentException($"The expression '{expression}' can't be empty.", nameof(expression));
      }

      this.OperationsList = this.ParseOperations(expression);
      if (!this.OperationsList.Any())
      {
        throw new ArgumentException($"The expression '{expression}' must have at least one operation.", nameof(expression));
      }

      this.VariablesList = this.ParseVariables(expression).Where(variable => !string.IsNullOrEmpty(variable)).ToArray();
      if (this.VariablesList.Length < 2)
      {
        throw new ArgumentException($"The expression '{expression}' must have at least two operands.", nameof(expression));
      }
    }

    protected string[] ParseVariables(string expression)
    {
      return expression.Split(this.operations);
    }

    protected string[] ParseOperations(string expression)
    {
      return expression.Split(this.digits).Where(operation => !string.IsNullOrEmpty(operation)).ToArray();
    }
  }
}