using SolidPrinciple.Following;

ILogger logger= new FileLogger();
OrderService localLogger = new OrderService(logger);
localLogger.CreateOrder(236);

ILogger logger1 = new CloudLogger();
OrderService globalLogger = new OrderService(logger1);
localLogger.CreateOrder(267);