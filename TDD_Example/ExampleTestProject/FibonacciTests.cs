using ExampleImplementation.Fibonacci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ExampleTestProject
{
  // Created once, shared among all tests in class
  public class FibonacciFixture
  {
    private Fibonacci impl = null;
    public Fibonacci GetImpl()
    {
      if (impl == null)
      {
        impl = new FibonacciImpl1();
      }
      return impl;
    }
  }

  public class FibonacciTests : IDisposable, IClassFixture<FibonacciFixture>
  {

    private Fibonacci impl;

    public FibonacciTests(FibonacciFixture fix)
    {
      impl = fix.GetImpl();
      //impl = new FibonacciImpl2();
    }

    public void Dispose()
    {
      // Dispose of resources if necessary
    }

    private static readonly int[] _CorrectFibs = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765 };
    public static IEnumerable<object[]> GetValidTestData()
    {
      for (int i = 0; i < 21; i++)
      {
        yield return new object[] { i, _CorrectFibs[i] };
      }
    }

    /// <summary>
    /// Checks that the nth fibonacci number is correct
    /// </summary>
    /// <param name="n"></param>
    [Theory]
    [MemberData(nameof(GetValidTestData))]
    public void Correct_Number_Fibonacci_n(int n, int correctResult)
    {
      var result = impl.GetFibonacci(n);
      Assert.Equal(correctResult, result);
    }

    [Fact]
    public void Correct_Fib_Number_7()
    {
      Assert.Equal(13, impl.GetFibonacci(7));
    }
  }
}
