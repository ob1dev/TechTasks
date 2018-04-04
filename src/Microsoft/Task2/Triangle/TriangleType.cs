using System;

namespace Triangle
{
  [Flags]
  public enum TriangleType
  {
    Unknown     = 0x0000,
    Equilateral = 0x0001,
    Isosceles   = 0x0010,
    Right       = 0x0100,
    Scalene     = 0x1000,
    All         = 0x1111
  }
}