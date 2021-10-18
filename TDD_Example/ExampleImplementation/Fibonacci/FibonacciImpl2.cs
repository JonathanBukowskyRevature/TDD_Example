using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleImplementation.Fibonacci
{
  public class FibonacciImpl2 : Fibonacci
  {
    public override long GetFibonacci(int n)
    {
      if (n == 0)
      {
        return 0;
      } else if (n == 1)
      {
        return 1;
      }
      return GetFibonacci(n - 1) + GetFibonacci(n - 2);
    }
  }
}
