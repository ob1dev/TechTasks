using List;
using Xunit;

namespace SinglyLinkedList.Tests
{
  public class SinglyLinkedList_IsPalindromeShould
  {
    [Fact]
    public void Return_True_Given_Sequence_Of_None()
    {
      // Arrange 
      var list = new SinglyLinkedList<int>();

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.True(actual);
    }

    [Fact]
    public void Return_True_Given_Sequence_Of_1()
    {
      // Arrange 
      var list = new SinglyLinkedList<int>(new[] { 1 });

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.True(actual);
    }

    [Fact]
    public void Return_True_Given_Sequence_Of_1_1()
    {
      // Arrange 
      var list = new SinglyLinkedList<int>(new[] { 1, 1 });

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.True(actual);
    }

    [Fact]
    public void Return_True_Given_Sequence_Of_1_2_1()
    {
      // Arrange 
      var list = new SinglyLinkedList<int>(new[] { 1, 2, 1 });

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.True(actual);
    }

    [Fact]
    public void Return_True_Given_Sequence_Of_1_1_1()
    {
      // Arrange 
      var list = new SinglyLinkedList<int>(new[] { 1, 1, 1 });

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.True(actual);
    }

    [Fact]
    public void Return_True_Given_Sequence_Of_2_5_5_2()
    {
      // Arrange 
      var list = new List.SinglyLinkedList<int>(new[] { 2, 5, 5, 2 });

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.True(actual);
    }

    [Fact]
    public void Return_False_Given_Sequence_Of_2_5()
    {
      // Arrange 
      var list = new List.SinglyLinkedList<int>(new[] { 2, 5 });

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.False(actual);
    }

    [Fact]
    public void Return_True_Given_Sequence_Of_2_1_3_1_2()
    {
      // Arrange 
      var list = new SinglyLinkedList<int>(new[] { 2, 1, 3, 1, 2 });

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.True(actual);
    }

    [Fact]
    public void Return_False_Given_Sequence_Of_2_5_5_1()
    {
      // Arrange 
      var list = new SinglyLinkedList<int>(new[] { 2, 5, 5, 1 });

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.False(actual);
    }

    [Fact]
    public void Return_False_Given_Sequence_Of_2_5_1_2()
    {
      // Arrange 
      var list = new SinglyLinkedList<int>(new[] { 2, 5, 1, 2 });

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.False(actual);
    }
  }
}