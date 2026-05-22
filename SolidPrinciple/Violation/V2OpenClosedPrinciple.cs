
namespace SolidPrinciple.Violation
{
    public class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }
    public class Circle
    {
        public double Radius { get; set; }
    }
    public class AreaCalculator
    {
        public double TotalArea(object[] shapes)
        {
            double totalArea = 0.0;
            foreach (var shape in shapes)
            {
                if (shape is Rectangle r)
                {
                    totalArea += r.Width * r.Height;
                }
                else if (shape is Circle c)
                {
                    totalArea += Math.PI * c.Radius * c.Radius;
                }
                //When a new shape Triangle added tomorrow than this method must be modified.
            }
            return totalArea;
        }
    }
}
