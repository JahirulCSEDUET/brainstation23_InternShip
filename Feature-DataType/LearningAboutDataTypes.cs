using System;
using System.Collections.Generic;
using System.Text;

namespace Feature_DataType
{
    public class LearningAboutDataTypes
    {
    }
    // 1. COMPLEX VALUE TYPE: Enum
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Cancelled
    }

    // 2. COMPLEX VALUE TYPE: Struct 
    public struct GeoLocation
    {
        public double Latitude { get; }
        public double Longitude { get; }

        public GeoLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    // USER-DEFINED REFERENCE TYPE: Class
    public class OrderProcessor
    {
        // USER-DEFINED REFERENCE TYPE: Delegate (Function pointer for callbacks)
        public delegate void LogHandler(string message);

        public void ProcessOrder()
        {
            // --- INTEGRAL NUMERIC TYPES (Signed & Unsigned Integers) ---
            sbyte temperatureRequirementCelsius = -18;          // sbyte: Small signed integer (-128 to 127)
            byte itemQuantity = 3;                               // byte: Small unsigned integer (0 to 255)
            short packagingBoxDepthMillimeters = 350;            // short: 16-bit signed integer
            ushort countryDialCode = 44;                         // ushort: 16-bit unsigned integer
            int customerId = 105432;                             // int: 32-bit signed integer (Standard for IDs)
            uint productSku = 4294967290;                        // uint: 32-bit unsigned integer
            long globalTransactionId = 9223372036854775807;      // long: 64-bit signed integer for massive numbers
            ulong cryptographicHash = 18446744073709551615;      // ulong: 64-bit unsigned integer

            // --- FLOATING-POINT NUMERIC TYPES (Decimals) ---
            float packageWeightKilograms = 2.45f;                // float: 32-bit precision (Requires 'f' suffix)
            double shippingDistanceMiles = 1450.85;              // double: 64-bit precision (Default for fractional numbers)
            decimal orderTotalAmount = 299.99m;                  // decimal: 128-bit high precision (Requires 'm' suffix, ideal for money)


            // --- OTHER SIMPLE VALUE TYPES ---
            bool isExpressShipping = true;                       // bool: Logical true/false
            char warehouseSection = 'B';                         // char: Single 16-bit Unicode character


            // --- BUILT-IN REFERENCE TYPES ---
            string customerNote = "Leave package at the front porch."; // string: Sequence of Unicode characters
            object genericMetadata = "Batch_A72";                // object: Base type of all .NET types
            dynamic flexibleData = "Initial string";             // dynamic: Bypasses compile-time checking
            flexibleData = 123;                                  // dynamic changed to an integer at runtime


            // --- SPECIAL TYPINGS & COLLECTIONS ---
            int? trackingNumber = null;                          // Nullable value type (Can hold an int or null)

            // Reference Type: Array
            string[] itemsOrdered = { "Laptop", "Mouse", "Keyboard Mat" };

            var deliveryLocation = new GeoLocation(51.5074, -0.1278);
            OrderStatus currentStatus = OrderStatus.Processing;

            // Instantiate delegate pointing to a clean method
            LogHandler logger = LogToConsole;

            logger($"Processing Order for Customer ID: {customerId}");
            logger($"Item Category Section: {warehouseSection}, Quantity: {itemQuantity}");
            logger($"Total Price Charged: ${orderTotalAmount}");
            logger($"Current Shipping Status: {currentStatus}");
            logger($"Coordinates: Lat {deliveryLocation.Latitude}, Long {deliveryLocation.Longitude}");

            if (trackingNumber == null)
            {
                logger("Tracking number has not been generated yet.");
            }
        }

        private void LogToConsole(string message)
        {
            Console.WriteLine($"[LOG] {message}");
        }
    }
}
