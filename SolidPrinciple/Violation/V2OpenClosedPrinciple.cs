
namespace SolidPrinciple.Violation
{
    public interface IShape
    {
        double CalculateArea();
    }

    public class Rectangle:IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double CalculateArea()=>(Width * Height);
    }
    public class Circle:IShape
    {
        public double Radius { get; set; }
        public double CalculateArea() => Math.PI * Radius *Radius;
    }
    public class AreaCalculator
    {
        public double CalculateArea(IShape shape) => shape.CalculateArea();
    }
}
