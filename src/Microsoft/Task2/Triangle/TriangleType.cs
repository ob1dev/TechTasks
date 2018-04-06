using System;

namespace Triangle
{
  [Flags]
  public enum TriangleType
  {
    Unknown,
    Equilateral,
    Isosceles,
    Right,
    Scalene
  }
}