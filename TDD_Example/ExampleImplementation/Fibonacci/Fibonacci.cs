using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleImplementation.Fibonacci
{
  public abstract class Fibonacci
  {
    /// <summary>
    /// Get the nth fibonacci number (starting from 0)
    /// </summary>
    /// <param name="n"></param>
    public abstract long GetFibonacci(int n);
  }

}
