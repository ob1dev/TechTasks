using System;
using System.Collections.Generic;
using Xunit;

namespace Intervals.Tests
{
  public class IntervalService_AddShould
  {
    private readonly IntervalService intervalService;

    public IntervalService_AddShould()
    {
      this.intervalService = new IntervalService();
    }

    [Fact]
    public void Insert_Single_Interval_Given_Interval()
    {
      // Arrange
      this.intervalService.Init(string.Empty);

      // Act
      var result = this.intervalService.Add("(3-5)").ToString();

      // Assert
      Assert.Equal("(3-5)", result);
    }

    [Fact]
    public void Insert_Single_Interval_At_Left_Given_Lower_Interval()
    {
      // Arrange    
      this.intervalService.Init("(3-5)");

      // Act
      var result = this.intervalService.Add("(1-2)").ToString();

      // Assert
      Assert.Equal("(1-2), (3-5)", result);
    }

    [Fact]
    public void Insert_Single_Interval_At_Right_Given_Greater_Interval()
    {
      // Arrange    
      this.intervalService.Init("3-5");

      // Act
      var result = this.intervalService.Add("(10-18)").ToString();

      // Assert
      Assert.Equal("(3-5), (10-18)", result);
    }

    [Theory]
    [InlineData("(3-5)", "(3-5)", "(3-5)")]
    [InlineData("(3-5)", "(3-6)", "(3-6)")]
    [InlineData("(3-5)", "(2-5)", "(2-5)")]
    [InlineData("(3-5)", "(2-6)", "(2-6)")]
    public void Replace_Single_Interval_Given_Wider_Interval(string input, string newInterval, string output)
    {
      // Arrange    
      this.intervalService.Init(input);

      // Act
      var result = this.intervalService.Add(newInterval).ToString();

      // Assert
      Assert.Equal(output, result);
    }

    [Theory]
    [InlineData("(3-5)", "(3-5)")]
    [InlineData("(4-5)", "(3-5)")]
    [InlineData("(3-4)", "(3-5)")]
    public void Keep_Single_Interval_Given_Same_Or_Narrower_Interval(string newInterval, string output)
    {
      // Arrange    
      this.intervalService.Init("(3-5)");

      // Act
      var result = this.intervalService.Add(newInterval).ToString();

      // Assert
      Assert.Equal(output, result);
    }


    [Theory]
    [InlineData("(3-5)", "(2-5)", "(2-5)")]
    [InlineData("(3-5)", "(2-4)", "(2-5)")]
    [InlineData("(3-5), (7-9)", "(6-8)", "(3-5), (6-9)")]
    public void Replace_Single_Interval_Given_Wider_Interval_At_Left(string input, string newInterval, string output)
    {
      // Arrange    
      this.intervalService.Init(input);

      // Act
      var result = this.intervalService.Add(newInterval).ToString();

      // Assert
      Assert.Equal(output, result);
    }


    [Theory]
    [InlineData("(3-6)", "(3-6)")]
    [InlineData("(4-6)", "(3-6)")]
    public void Replace_Single_Interval_Given_Wider_Interval_At_Right(string newInterval, string output)
    {
      // Arrange    
      this.intervalService.Init("(3-5)");

      // Act
      var result = this.intervalService.Add(newInterval).ToString();

      // Assert
      Assert.Equal(output, result);
    }

    [Fact]
    public void Insert_Interval_Between_Two_Intervals()
    {
      // Arrange    
      this.intervalService.Init("(3-5), (10-18)");

      // Act
      var result = this.intervalService.Add("(7-9)").ToString();

      // Assert
      Assert.Equal("(3-5), (7-9), (10-18)", result);
    }

    [Fact]
    public void Insert_Interval_Between_Two_Intervals_Given_Wider_Interval_At_Left()
    {
      // Arrange    
      this.intervalService.Init("(3-5), (7-9), (10-18)");

      // Act
      var result = this.intervalService.Add("(4-6)").ToString();

      // Assert
      Assert.Equal("(3-6), (7-9), (10-18)", result);
    }

    [Fact]
    public void Insert_Interval_Between_Two_Intervals_Given_Wider_Interval_At_Right()
    {
      // Arrange    
      this.intervalService.Init("(3-6), (7-9), (10-18)");

      // Act
      var result = this.intervalService.Add("(10-21)").ToString();

      // Assert
      Assert.Equal("(3-6), (7-9), (10-21)", result);
    }

    [Theory]
    [InlineData("(3-5), (7-9), (11-13)", "(5-11)", "(3-13)")]
    [InlineData("(3-5), (7-9), (11-13)", "(4-12)", "(3-13)")]
    [InlineData("(3-5), (7-9), (11-13)", "(3-13)", "(3-13)")]
    [InlineData("(3-5), (7-9), (11-13)", "(2-14)", "(2-14)")]
    public void Replace_Intervals_Given_Wider_Interval(string input, string newInterval, string output)
    {
      // Arrange    
      this.intervalService.Init(input);

      // Act
      var result = this.intervalService.Add(newInterval).ToString();

      // Assert
      Assert.Equal(output, result);
    }
  }
}