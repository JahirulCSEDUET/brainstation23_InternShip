using SolidPrinciple.Following;

ILogger logger= new FileLogger();
OrderService localLogger = new OrderService(logger);
localLogger.CreateOrder(236);

ILogger logger1 = new CloudLogger();
OrderService globalLogger = new OrderService(logger1);
globalLogger.CreateOrder(267);
﻿using SolidPrinciple.Violation;

var alerts = new List<INotification>
{
    new EmailNotification
    {
        EmailAddress="jahirulcseduet@gmail.com",
        Subject="System alert",
        Message ="Server is down!"
    },
    new SmsNotification
    {
        PhoneNumber ="+8801626467279",
        Message ="Server is down!"
    },
    new PushNotification
    {
        DeviceToken="jdsxchsnls",
        Message="Server is down!"
    }
};
foreach(var alert in alerts)
{
    alert.send();
}



//for Open Close Principle Following 
var calculator = new AreaCalculator();
var rectangle = new Rectangle();
var circle  = new Circle();
Console.WriteLine("Area of Circle: " + calculator.CalculateArea(circle));
Console.WriteLine("Area of Rectangle: " + calculator.CalculateArea(rectangle));
