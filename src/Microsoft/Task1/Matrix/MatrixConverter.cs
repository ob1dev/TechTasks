using System;
using System.Text;

namespace Matrix
{
  public class MatrixConverter
  {
    public static string ToArray(int[,] matrix)
    {
      if (matrix.Rank != 2)
      {
        throw new ArgumentException($"The given array has '{matrix.Rank}' dimension(s), while it must be two-dimensional array.", nameof(matrix));
      }

      int rowMin = 0;
      int columnMin = 0;

      int rowMax = matrix.GetLength(0);
      int columnMax = matrix.GetLength(1);

      int rowIndex = 0;
      int columnIndex = 0;

      var result = new StringBuilder();
      Direction direction = Direction.Right;

      for (int index = 0; index < matrix.Length; index++)
      {
        result.Append(matrix[rowIndex, columnIndex])
              .Append(' ');

        switch (direction)
        {
          case Direction.Right:
            {
              if (columnIndex + 1 == columnMax)
              {
                direction = Direction.Down;

                rowIndex++;
                rowMin++;
              }
              else
              {
                columnIndex++;
              }

              break;
            }

          case Direction.Down:
            {
              if (rowIndex + 1 == rowMax)
              {
                direction = Direction.Left;

                columnIndex--;
                columnMax--;
              }
              else
              {
                rowIndex++;
              }

              break;
            }

          case Direction.Left:
            {
              if (columnIndex - 1 < columnMin)
              {
                direction = Direction.Up;

                rowIndex--;
                rowMax--;
              }
              else
              {
                columnIndex--;
              }

              break;
            }

          case Direction.Up:
            {
              if (rowIndex - 1 < rowMin)
              {
                direction = Direction.Right;
                columnIndex++;
                columnMin++;
              }
              else
              {
                rowIndex--;
              }

              break;
            }
        }
      }

      return result.ToString().Trim();
    }
  }
}