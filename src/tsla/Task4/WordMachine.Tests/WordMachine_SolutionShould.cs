using Xunit;

namespace Task2.Tests
{
  public class UnitTest1
  {
    [Fact]
    public void Return_Negative_1_Given_Empty_Expression()
    {
      // Arrange 
      var machine = new WordMachine();
      var expression = "";

      // Act
      var actual = machine.Solution(expression);

      // Assert
      Assert.Equal(-1, actual);
    }

    [Fact]
    public void Return_Negative_1_Given_5_6_Plus_Minus()
    {
      // Arrange 
      var machine = new WordMachine();
      var expression = "5 6 + -";

      // Act
      var actual = machine.Solution(expression);

      // Assert
      Assert.Equal(-1, actual);
    }

    [Fact]
    public void Return_Negative_1_Given_3_DUP_5_Minus_Minus()
    {
      // Arrange 
      var machine = new WordMachine();
      var expression = "3 DUP 5 - -";

      // Act
      var actual = machine.Solution(expression);

      // Assert
      Assert.Equal(-1, actual);
    }

    [Fact]
    public void Return_Negative_1_Given_5_5_Minus_Pop()
    {
      // Arrange 
      var machine = new WordMachine();
      var expression = "5 5 - POP";

      // Act
      var actual = machine.Solution(expression);

      // Assert
      Assert.Equal(-1, actual);
    }

    [Fact]
    public void Return_7_Given_13_DUP_4_POP_5_DUP_Plus_DUP_Plus_Minus()
    {
      // Arrange 
      var machine = new WordMachine();
      var expression = "13 DUP 4 POP 5 DUP + DUP + -";

      // Act
      var actual = machine.Solution(expression);

      // Assert
      Assert.Equal(7, actual);
    }
  }
}