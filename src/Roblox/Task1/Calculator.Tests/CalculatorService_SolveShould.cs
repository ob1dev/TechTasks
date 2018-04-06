using System;
using Xunit;

namespace Calculator.Tests
{
  public class CalculatorService_SolveShould
  {
    private readonly CalculatorService calculatorService;

    public CalculatorService_SolveShould()
    {
      this.calculatorService = new CalculatorService();
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Throw_Exception_Given_Empty_Expression(string expression)
    {
      // Act
      Exception ex = Assert.Throws<ArgumentException>(() => this.calculatorService.Solve(expression));

      // Assert
      Assert.StartsWith($"The expression '{expression}' can't be empty.", ex.Message);
    }

    [Fact]
    public void Throw_Exception_Given_One_Operand()
    {
      // Arrange 
      var expression = "1+";

      // Act
      Exception ex = Assert.Throws<ArgumentException>(() => this.calculatorService.Solve(expression));

      // Assert
      Assert.StartsWith($"The expression '{expression}' must have at least two operands.", ex.Message);
    }

    [Fact]
    public void Throw_Exception_Given_No_Operation()
    {
      // Arrange 
      var expression = "1";

      // Act
      Exception ex = Assert.Throws<ArgumentException>(() => this.calculatorService.Solve(expression));

      // Assert
      Assert.StartsWith($"The expression '{expression}' must have at least one operation.", ex.Message);
    }

    [Theory]
    [InlineData("6+9-12", 3)]
    [InlineData("1+2-3+4-5+6-7", -2)]
    [InlineData("11+22-33+0-0", 0)]
    public void Return_Result_Given_Correct_Expression(string expression, int expectedResult)
    {
      // Act
      var actualResult = this.calculatorService.Solve(expression);

      // Assert
      Assert.Equal(expectedResult, actualResult);
    }
  }
}
