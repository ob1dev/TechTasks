using List;
using Xunit;

namespace SinglyLinkedList.Tests
{
  public class SinglyLinkedList_IsPalindromeShould
  {
    [Fact]
    public void Return_True_Given_Empty_Sequence_Of_Numbers()
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
    public void Return_True_Given_Trivial_Sequence_Of_Numbers(int[] sequence)
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
    public void Return_True_Given_Palindrome_Sequence_Of_Numbers(int[] sequence)
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
    public void Return_False_Given_Not_Palindrome_Sequence_Of_Numbers(int[] sequence)
    {
      // Arrange 
      var list = new SinglyLinkedList<int>(sequence);

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.False(actual);
    }

    [Fact]
    public void Return_True_Given_Empty_Sequence_Of_Characters()
    {
      // Arrange 
      var list = new SinglyLinkedList<char>();

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.True(actual);
    }

    [Theory]
    [InlineData(new[] { 'I' })]
    [InlineData(new[] { 'd', 'a', 'd' })]
    [InlineData(new[] { 'y', 'e', 'y' })]
    public void Return_True_Given_Trivial_Sequence_Of_Characters(char[] sequence)
    {
      // Arrange 
      var list = new SinglyLinkedList<char>(sequence);

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.True(actual);
    }

    [Theory]
    [InlineData(new[] { 'r', 'o', 't', 'o', 'r' })]
    [InlineData(new[] { 'l', 'e', 'v', 'e', 'l' })]
    [InlineData(new[] { 'r', 'a', 'c', 'e', 'c', 'a', 'r' })]
    public void Return_True_Given_Palindrome_Sequence_Of_Characters(char[] sequence)
    {
      // Arrange 
      var list = new SinglyLinkedList<char>(sequence);

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.True(actual);
    }

    [Theory]
    [InlineData(new[] { 'c', 'a', 't' })]
    [InlineData(new[] { 'd', 'o', 'g' })]
    [InlineData(new[] { 'a', 'n', 'd' })]
    public void Return_False_Given_Not_Palindrome_Sequence_Of_Characters(char[] sequence)
    {
      // Arrange 
      var list = new SinglyLinkedList<char>(sequence);

      // Act
      var actual = list.IsPalindrome();

      // Assert
      Assert.False(actual);
    }
  }
}