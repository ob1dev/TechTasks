using System;
using System.Collections.Generic;

namespace Triangle
{
  /// <summary>
  /// Represents the geometric shape service. 
  /// For more details about triangle see at https://en.wikipedia.org/wiki/Triangle.
  /// </summary>
  public class ShapeService
  {
    public List<TriangleType> TrianglesTypes { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ShapeService"/> class.
    /// </summary>
    public ShapeService()
    {
      this.TrianglesTypes = new List<TriangleType>()
        {
          TriangleType.Equilateral,
          TriangleType.Isosceles,
          TriangleType.Right,
          TriangleType.Scalene
        };
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ShapeService"/> class.
    /// </summary>
    /// <param name="options">The types of triangles that need to be classified.
    public ShapeService(List<TriangleType> typesList)
    {
      this.TrianglesTypes = typesList;
    }

    public TriangleType ClassifyTriangle(int a, int b, int c)
    {
      if (!this.IsRealTriangle(a, b, c))
      {
        throw new ArgumentException($"Triangle with the given lengths of the sides a='{a}', b='{b}' and c='{c}' does not exist." +
          $"{Environment.NewLine}The sum of the lengths of any two sides of a triangle must be greater than or equal to the length of the third side.");
      }

      var result = TriangleType.Unknown;

      foreach (var type in this.TrianglesTypes)
      {
        if (result != TriangleType.Unknown)
        {
          break;
        }

        switch (type)
        {
          case TriangleType.Equilateral:
            {
              if (this.IsEquilateralType(a, b, c))
              {
                result = TriangleType.Equilateral;
              }

              break;
            }

          case TriangleType.Isosceles:
            {
              if (this.IsIsoscelesType(a, b, c))
              {
                result = TriangleType.Isosceles;
              }

              break;
            }

          case TriangleType.Right:
            {
              if (this.IsRightType(a, b, c))
              {
                result = TriangleType.Right;
              }

              break;
            }

          case TriangleType.Scalene:
            {
              if (this.IsScaleneType(a, b, c))
              {
                result = TriangleType.Scalene;
              }

              break;
            }

          default:
            {
              result = TriangleType.Unknown;
              break;
            }
        }
      }

      return result;
    }

    #region Protected Methods

    protected bool IsRealTriangle(int a, int b, int c)
    {
      bool triangleExist = true;

      // All sides must have positive length.
      if (a <= 0 || b <= 0 || c <= 0)
      {
        triangleExist = false;
      }
      // The sum of the lengths of any two sides of a triangle must be greater than the length of the third side for non-degenerate triangle.
      else if (((long)a + b) <= c)
      {
        triangleExist = false;
      }
      else if (((long)a + c) <= b)
      {
        triangleExist = false;
      }
      else if (((long)b + c) <= a)
      {
        triangleExist = false;
      }

      return triangleExist;
    }

    // An equilateral triangle has all sides the same length. 
    // An equilateral triangle is also a regular polygon with all angles measuring 60°.
    protected bool IsEquilateralType(int a, int b, int c)
    {
      return (a == b && a == c);
    }

    // An isosceles triangle has two sides of equal length.
    // An isosceles triangle also has two angles of the same measure.
    protected bool IsIsoscelesType(int a, int b, int c)
    {
      return (a == b || a == c || b == c);
    }

    // A right triangle has the square of the length of the hypotenuse equals the sum of the squares of the lengths of the two other sides.
    // A right triangle also has 90° angel (a right angle) opposite to its hypotenuse.
    protected bool IsRightType(int a, int b, int c)
    {
      var result = false;

      if (c > a && c > b)
      {
        result = (a * a + b * b == c * c);
      }
      else if (a > b && a > c)
      {
        result = (b * b + c * c == a * a);
      }
      else if (b > a && b > c)
      {
        result = (a * a + c * c == b * b); ;
      }

      return result;
    }

    // A scalene triangle has all sides different lengths, or equivalently all angles are unequal.
    protected bool IsScaleneType(int a, int b, int c)
    {
      return (a != b && a != c && b != c);
    }

    #endregion
  }
}