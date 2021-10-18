using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleImplementation.Shapes
{
  public abstract class Shape
  {
    protected Shape() { }
    public abstract double GetArea();
  }

  public abstract class ShapeFactory
  {
    public abstract Shape Factory();
  }

}
