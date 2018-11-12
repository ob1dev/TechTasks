using List;
using Xunit;

namespace SinglyLinkedList.Tests
{
  public class SinglyLinkedList_IsPalindromeShould
  {
    [Fact]
    public void Return_True_Given_Empty_Sequence()
    {
      // Arrange 
      var list = new SinglyLinkedList<int>();

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.True(actual);
    }

    [Theory]
    [InlineData(new[] { 1 })]
    [InlineData(new[] { 1, 1 })]
    [InlineData(new[] { 1, 1, 1 })]
    [InlineData(new[] { 1, 2, 1 })]
    public void Return_True_Given_Trivial_Sequence(int[] sequence)
    {
      // Arrange 
      var list = new SinglyLinkedList<int>(sequence);

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.True(actual);
    }

    [Theory]
    [InlineData(new[] { 2, 5, 5, 2 })]
    [InlineData(new[] { 2, 5, 0, 5, 2 })]
    [InlineData(new[] { 2, 5, 0, 0, 5, 2 })]
    [InlineData(new[] { 2, 5, 0, 1, 0, 5, 2 })]
    public void Return_True_Given_Palindrome_Sequence(int[] sequence)
    {
      // Arrange 
      var list = new SinglyLinkedList<int>(sequence);

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.True(actual);
    }

    [Theory]
    [InlineData(new[] { 2, 5 })]
    [InlineData(new[] { 2, 5, 0 })]
    [InlineData(new[] { 2, 5, 5, 0 })]
    [InlineData(new[] { 2, 5, 0, 2 })]
    [InlineData(new[] { 2, 5, 0, 5, 1 })]
    [InlineData(new[] { 2, 5, 0, 4, 2 })]
    public void Return_False_Given_Not_Palindrome_Sequence(int[] sequence)
    {
      // Arrange 
      var list = new SinglyLinkedList<int>(sequence);

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.False(actual);
    }
  }
}