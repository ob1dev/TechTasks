using System;

namespace Graph
{
  internal static class Assert
  {
    internal static void ArgumentNotNull(object argument, string argumentName)
    {
      if (argument == null)
      {
        if (argumentName != null)
        {
          throw new ArgumentNullException(argumentName);
        }
        throw new ArgumentNullException();
      }
    }
  }
}