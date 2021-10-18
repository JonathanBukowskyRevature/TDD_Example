using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleImplementation.Fibonacci
{
  public class FibonacciImpl3 : Fibonacci
  {

    private List<long> _memo = new() { 0, 1 };

    public override long GetFibonacci(int n)
    {
      while (n > _memo.Count())
      {
        _memo.Add(_memo[_memo.Count - 1] +_memo[_memo.Count - 2]);
      }
      return _memo[n];
    }
  }
}
