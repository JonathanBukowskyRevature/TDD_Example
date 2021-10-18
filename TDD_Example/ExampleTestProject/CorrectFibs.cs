using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleTestProject
{

  public class FibEnumerator : IEnumerator<object[]>
  {
    // IEnumerator<object[]>.Current
    public object[] Current { get => new object[] { index, c }; }

    // IEnumerator.Current (for non-generic collections, must be implemented)
    object IEnumerator.Current { get => (object)Current; }

    private int _length;
    private int index = -1;
    private long a = 0L;
    private long b = 1L;
    private long c = 0L;
    public FibEnumerator(int length)
    {
      _length = length;
    }

    public void Dispose()
    {
      // nothing to do
    }

    public bool MoveNext()
    {
      index++;
      if (index >= _length)
      {
        return false;
      }
      if (index == 0)
      {
        c = 0;
      }
      else if (index == 1)
      {
        c = 1;
      }
      else
      {
        c = a + b;
        a = b;
        b = c;
      }
      return true;
    }

    public void Reset()
    {
      throw new NotImplementedException();
    }
  }

  public class CorrectFibs : IEnumerable<object[]>
  {
    //private int _length = 1000;
    public static int LENGTH = 10000;

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

    private static IEnumerable<object[]> CorrectWithIndex()
    {
      int i = 0;
      foreach (var fib in GetCorrectFibs(LENGTH))
      {
        yield return new object[] { i++, fib };
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      //return new FibEnumerator(_length);
      var correctFibs = CorrectWithIndex();
      return correctFibs.GetEnumerator();
    }

    IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator()
    {
      //return new FibEnumerator(_length);
      var correctFibs = CorrectWithIndex();
      return correctFibs.GetEnumerator();
    }
  }

}
