using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
public enum TripStatus { Pending, Paid, Failed }
public interface IPromotion
{
    decimal ApplyDiscount(decimal currentFare);
}
public interface IPaymentService
{
    bool ProcessPayment(int passengerId, decimal amount);
}
public abstract class Vehicle
{
    public string LicensePlate {  get; init; } 
    public decimal BaseFare { get; init; }
    public abstract decimal PerKmRate { get; }
    public abstract decimal PerMinuteRate {  get; }
    protected Vehicle(string licensePlate, decimal baseFare)
    {
        if (baseFare < 0)
        {
            throw new ArgumentOutOfRangeException("Base fare cannot be negative.");
        }
        if (string.IsNullOrWhiteSpace(licensePlate))
        {
            throw new ArgumentException("License plate cannot be empty.");
        }
        LicensePlate = licensePlate;
        BaseFare = baseFare;
    }
    public abstract decimal CalculateVehicleFare(double distanceKms, double durationMinutes);
}
public class StandardCar : Vehicle
{
    public override decimal PerKmRate => 1.5m;
    public override decimal PerMinuteRate => 0.04m;
    public StandardCar(string licensePlate, decimal baseFare) : base(licensePlate, baseFare)
    {
        
    }
    public override decimal CalculateVehicleFare(double distanceKms, double durationMinutes)
    {
        return BaseFare + ((decimal) distanceKms *  PerKmRate) + ((decimal) durationMinutes * PerMinuteRate);
    }
}
public class LuxurySedan : Vehicle
{
    public override decimal PerKmRate => 3.0m;
    public override decimal PerMinuteRate => 0.08m;
    public decimal LuxuryTax { get; init; }
    public LuxurySedan(string licensePlate, decimal baseFare, decimal luxuryTax) :base(licensePlate, baseFare) {
        if (luxuryTax < 0)
        {
            throw new ArgumentOutOfRangeException("Luxury tax cannot be negative!");
        }
        LuxuryTax = luxuryTax;
    }

    public override decimal CalculateVehicleFare(double distanceKms, double durationMinutes)
    {
        return BaseFare + ((decimal)distanceKms * PerKmRate) + ((decimal)durationMinutes * PerMinuteRate)+LuxuryTax;
    }
}
public class Passanger
{
    public int Id { get; init; }
    public string Name { get; init; }
    public Passanger(int id, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Passenger Name cannot be empty.");
        }
        Id = id;
        Name = name;
    }
}
public class InvalidTripException : Exception
{
    public InvalidTripException() { }
    public InvalidTripException(string message) : base(message) { }
}

public class Trip
{
    public Vehicle AssigndVehicle {  get; init; }
    public Passanger Passanger { get; init; }
    public IPromotion OptionalPromotion { get; init; }
    public double DistanceKms {  get; init; }
    public double DurationMinutes { get; init; }
    public TripStatus Status { get; private set; } = TripStatus.Pending;
    public Trip(Vehicle vehicle, Passanger passanger, double distanceKms, double durationMinutes, IPromotion optionalPromotion=null)
    {
        if (vehicle == null)
        {
            throw new InvalidTripException("A valid vehicle must be assigned to the trip.");
        }
        if (passanger == null)
        {
            throw new ArgumentException("Passenger cannot be null.");
        }
        if (distanceKms < 0)
        {
            throw new ArgumentOutOfRangeException("Distance cannot be negative.");
        }
        if (durationMinutes < 0)
        {
            throw new ArgumentOutOfRangeException("Time cannot be negetive.");
        }
        AssigndVehicle = vehicle;
        Passanger = passanger;
        DistanceKms = distanceKms;
        DurationMinutes = durationMinutes;
        OptionalPromotion = optionalPromotion;
    }
    public decimal CalculateFinalFare()
    {
        decimal dynamicFare = AssigndVehicle.CalculateVehicleFare(DistanceKms, DurationMinutes);
        if (OptionalPromotion != null)
        {
            dynamicFare = OptionalPromotion.ApplyDiscount(dynamicFare);
        }
        return Math.Max(dynamicFare, AssigndVehicle.BaseFare);
    }
    public void CompleteTrip(IPaymentService paymentService)
    {
        if (paymentService == null)
        {
            throw new ArgumentNullException(nameof(paymentService));
        }
        if (Status == TripStatus.Paid)
        {
            new InvalidOperationException("This trip has already been paid.");
        }            

        decimal totalAmount = CalculateFinalFare();
        bool paymentSuccess = paymentService.ProcessPayment(Passanger.Id, totalAmount);

        Status = paymentSuccess ? TripStatus.Paid : TripStatus.Failed;
    }


}

public class PercentageDiscount : IPromotion
{
    private readonly decimal _parcentage;
    public PercentageDiscount(decimal parcentage)
    {
        if(parcentage < 0 || parcentage>1)
        {
          throw new ArgumentOutOfRangeException( "Percentage must be between 0.0 and 1.0");
        }
        _parcentage = parcentage;
    }
    public decimal ApplyDiscount(decimal currentFare)
    {
        return currentFare - currentFare * _parcentage;
    }
}
public class FlatDiscount : IPromotion
{
    private readonly decimal _amount;
    public FlatDiscount(decimal amount)
    {
        _amount = amount;
    }
    public decimal ApplyDiscount(decimal currentFare)
    {
        return currentFare - _amount;
    }
}

public class CreditCardPaymentService : IPaymentService
{
    public bool ProcessPayment(int passengerId, decimal amount)
    {
        Console.WriteLine($"[Gateway] Charging card of Passenger '{passengerId}' for ${amount:F2}...");
        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Executing Ride-Sharing Fare Engine Tests ===\n");
        
        var passenger = new Passanger(123, "Alice Smith");
        var paymentService = new CreditCardPaymentService();

        var standardCar = new StandardCar("ABC-123", baseFare: 5.00m);
        var luxurySedan = new LuxurySedan("VIP-777", baseFare: 15.00m, luxuryTax: 10.00m);

        try
        {
            var trip1 = new Trip(standardCar, passenger, distanceKms: 10, durationMinutes: 20);
            Console.WriteLine($"Trip 1 (Standard): Calculated Fare = ${trip1.CalculateFinalFare():F2}");
            trip1.CompleteTrip(paymentService);
            Console.WriteLine($"Trip 1 Status: {trip1.Status}\n");
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine($"Caught Expected Exception successfully: {ex.Message}");
        }
        try
        {
            var promo10Percent = new PercentageDiscount(0.10m);
            var trip2 = new Trip(luxurySedan, passenger, distanceKms: 10, durationMinutes: 20, optionalPromotion: promo10Percent);
            Console.WriteLine($"Trip 2 (Luxury + 10% Promo): Calculated Fare = ${trip2.CalculateFinalFare():F2}");
            trip2.CompleteTrip(paymentService);
            Console.WriteLine($"Trip 2 Status: {trip2.Status}\n");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Caught Expected Exception successfully: {ex.Message}");
        }
        try
        {
            var aggressiveDiscount = new FlatDiscount(5.00m);
            var trip3 = new Trip(standardCar, passenger, distanceKms: 1, durationMinutes: 2, optionalPromotion: aggressiveDiscount);
            Console.WriteLine($"Trip 3 (Standard Short + $5 Off): Calculated Fare = ${trip3.CalculateFinalFare():F2} (Should floor at $5.00 BaseFare)");
            trip3.CompleteTrip(paymentService);
            Console.WriteLine($"Trip 3 Status: {trip3.Status}\n");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Caught Expected Exception successfully: {ex.Message}");
        }

      
        try
        {
            var invalidTrip = new Trip(standardCar, passenger, distanceKms: -5, durationMinutes: 10);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Caught Expected Exception successfully: {ex.Message}");
        }

    }
}