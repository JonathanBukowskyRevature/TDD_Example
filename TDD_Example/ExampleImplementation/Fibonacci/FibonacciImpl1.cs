using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleImplementation.Fibonacci
{
  public class FibonacciImpl1 : Fibonacci
  {
    public override long GetFibonacci(int n)
    {
      int i = 1;
      int a = 0;
      int b = 1;
      int c;
      if (n == 0)
      {
        return a;
      }
      else if (n == 1)
      {
        return b;
      }
      do
      {
        c = a + b;
        a = b;
        b = c;
      } while (++i < n);
      return c;
    }
  }
}
