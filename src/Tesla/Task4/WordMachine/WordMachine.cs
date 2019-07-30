using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
  public class WordMachine
  {
    private readonly int MaxOperations = 2000;
    private readonly char OperationSeparator = ' ';
    private readonly int MaxValue = 1048575; // 2^20
    private readonly int ErrorCode = -1;

    public int Solution(string expression)
    {
      var operations = expression.Split(new[] { this.OperationSeparator });

      if (!this.IsValidExpression(expression))
      {
        return -1;
      }

      var stack = new Stack<int>();

      foreach (var item in operations)
      {
        try
        {
          switch (item)
          {
            case "POP":
              {
                stack.Pop();

                break;
              }

            case "DUP":
              {
                var topMostNumber = stack.Peek();
                stack.Push(topMostNumber);

                break;
              }

            case "+":
              {
                var operand1 = stack.Pop();
                var operand2 = stack.Pop();

                var sum = operand1 + operand2;
                this.ValidateSum(sum);

                stack.Push(sum);

                break;
              }

            case "-":
              {
                var operand1 = stack.Pop();
                var operand2 = stack.Pop();

                var sum = operand1 - operand2;
                this.ValidateSum(sum);

                stack.Push(sum);

                break;
              }

            default:
              {
                stack.Push(int.Parse(item));

                break;
              }
          }
        }
        catch (Exception ex)
        {
          if (ex is InvalidOperationException || ex is StackOverflowException)
          {
            return this.ErrorCode;
          }
        }
      }

      return stack.Any() ? stack.Pop() : this.ErrorCode;
    }

    public bool IsValidExpression(string s)
    {
      var result = false;
      var length = s.Length;

      if (length > 0 || length <= this.MaxOperations)
      {
        result = true;
      }

      return result;
    }

    public void ValidateSum(int number)
    {
      if (number < 0 || number > this.MaxValue)
      {
        throw new StackOverflowException();
      }
    }
  }
}