using ExampleImplementation.Fibonacci;
using System;
using System.Collections;
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
        //impl = new FibonacciImpl1();
        impl = new FibonacciImpl3();
      }
      return impl;
    }
  }

  public class FibonacciTests : IDisposable, IClassFixture<FibonacciFixture>
  {

    private readonly Fibonacci impl;

    public FibonacciTests(FibonacciFixture fix)
    {
      impl = fix.GetImpl();
      //impl = new FibonacciImpl3();
    }

    public void Dispose()
    {
      // Dispose of resources if necessary
    }

    /// <summary>
    /// Get correct fibonacci numbers up to *length*
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    private static IEnumerable<long> GetCorrectFibs(int length)
    {
      int i = 0;
      long a = 0;
      long b = 1;
      if (length < 1) yield break;
      yield return a;
      if (length < 1) yield break;
      yield return b;
      long c;
      do
      {
        c = a + b;
        a = b;
        b = c;
        yield return c;
      } while (i++ < length);
    }

    public static IEnumerable<object[]> GetValidTestData()
    {
      int i = 0;
      foreach (var fib in GetCorrectFibs(CorrectFibs.LENGTH))
      {
        yield return new object[] { i++, fib };
      }
    }

    /// <summary>
    /// Checks that the nth fibonacci number is correct
    /// </summary>
    /// <param name="n"></param>
    [Theory]
    [MemberData(nameof(GetValidTestData))]
    public void Correct_Number_Fibonacci_n(int n, long correctResult)
    {
      var result = impl.GetFibonacci(n);
      Assert.Equal(correctResult, result);
    }

    [Theory]
    [ClassData(typeof(CorrectFibs))]
    public void Correct_Number_Fibonacci_n_2(int n, long correctResult)
    {
      var result = impl.GetFibonacci(n);
      Assert.Equal(correctResult, result);
    }


    [Fact]
    public void Correct_Fib_Number_7()
    {
      Assert.Equal(13L, impl.GetFibonacci(7));
    }

    [Fact]
    public void Negative_Argument_Will_Throw()
    {
      Assert.Throws<ArgumentOutOfRangeException>(() => impl.GetFibonacci(-1));
      Assert.Throws<ArgumentOutOfRangeException>(() => impl.GetFibonacci(-100));
    }
  }
}
