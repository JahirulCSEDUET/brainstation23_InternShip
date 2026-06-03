using SolidPrinciple.Violation;


//for Open Close Principle Following 
var calculator = new AreaCalculator();
var rectangle = new Rectangle();
var circle  = new Circle();
Console.WriteLine("Area of Circle: " + calculator.CalculateArea(circle));
Console.WriteLine("Area of Rectangle: " + calculator.CalculateArea(rectangle));