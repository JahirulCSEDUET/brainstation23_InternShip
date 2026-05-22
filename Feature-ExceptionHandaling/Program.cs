//Exception Handaling try-catch-finnaly
try
{
    int denominator = 0;
    int result = 10 / denominator; // This will cause a DivideByZeroException
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Cannot divide by zero: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"A error occurred: {ex.Message}");
}
finally
{
    Console.WriteLine("Cleanup operations executed safely.");
}

//File Not Fund Exception
try
{
    string fileContent = File.ReadAllText("non_existent_file.txt");
}
catch (FileNotFoundException ex) // Highly Specific
{
    Console.WriteLine($"The specific file was missing: {ex.FileName}");
}
catch (IOException ex) // Broader category (Input/Output errors)
{
    Console.WriteLine($"An I/O disk error occurred: {ex.Message}");
}
catch (Exception ex) // Ultimate fallback (All exceptions inherit from this)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
}

//Throwing Exceptions Manually
void SetAccountAge(int age)
{
    if (age < 18)
    {
        // Prevent the system from processing invalid domain data
        throw new ArgumentOutOfRangeException("Users must be 18 or older to register.");
    }

    Console.WriteLine("Age successfully updated.");
}

try
{
    SetAccountAge(12);
}
catch( ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}