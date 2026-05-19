using System;

namespace ParameterPassingDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            // 1. 1. Function with Return
            Console.WriteLine("1. Function with Return");
            double basePrice = 100.00;
            double salesTaxRate = 0.15; // 15%
            double totalPrice = CalculateTotalWithTax(basePrice, salesTaxRate);
            Console.WriteLine($" Base: ${basePrice} + Tax: {salesTaxRate * 100}% = Total: ${totalPrice}\n");

            // 2. Call by Value 
            Console.WriteLine("2. Call by value");
            int originalValue = 10;
            Console.WriteLine($"Before Attempt: {originalValue}");
            AttemptModifyValue(originalValue);
            Console.WriteLine($"After Attempt: {originalValue} (Unchanged - original copy preserved)\n");


            // 3. Call by Reference (ref)
            Console.WriteLine("3. Call by reference(ref)");
            int firstItemValue = 50;
            int secondItemValue = 100;

            Console.WriteLine($"Before Swap: Item1 = {firstItemValue}, Item2 = {secondItemValue}");

            SwapValues(ref firstItemValue, ref secondItemValue);

            Console.WriteLine($"After Swap: Item1 = {firstItemValue}, Item2 = {secondItemValue} (Successfully swapped directly in memory)\n");


            // 4. Out Parameter (out)
            Console.WriteLine("4. Out Parameter (out)");
            int dividend = 10;
            int divisor = 3;

            DivideAndFetchRemainder(dividend, divisor, out int quotientResult, out int remainderResult);

            Console.WriteLine($"Math Operation: {dividend} divided by {divisor}");
            Console.WriteLine($"Quotient (Returned normally): {quotientResult}");
            Console.WriteLine($"Remainder (Returned via out): {remainderResult}");
        }
        public static double CalculateTotalWithTax(double itemPrice, double taxRate)
        {
            return itemPrice + (itemPrice * taxRate);
        }

        public static void AttemptModifyValue(int localNumberCopy)
        {
            localNumberCopy += 500; 
        }

        public static void SwapValues(ref int leftSide, ref int rightSide)
        {
            int structuralTemporaryHolding = leftSide;
            leftSide = rightSide;
            rightSide = structuralTemporaryHolding;
        }

        public static void DivideAndFetchRemainder(int numerator, int denominator, out int quotient, out int remainder)
        {
            quotient = numerator / denominator;
            remainder = numerator % denominator;
        }
    }
}