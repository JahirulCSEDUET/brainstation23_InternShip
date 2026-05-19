//foreach loop 
string[] activeUsers = { "Jahirul", "Islam", "Nayem" };

foreach (string user in activeUsers)
{
    Console.WriteLine($"Sending email notification to: {user}");
}

//for loop index based
// Iterates exactly 5 times (indices 0 through 4)
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Current step sequence index: {i}");
}

//While loop
int healthPoints = 100;
bool isPoisoned = true;

while (healthPoints > 0 && isPoisoned)
{
    healthPoints -= 10; // Applies damage tick
    Console.WriteLine($"Remaining Health: {healthPoints}");

    if (healthPoints <= 20)
    {
        isPoisoned = false; // Antidote applied automatically
    }
}

//Do While loop

int userSelection;

do
{
    Console.WriteLine("--- System Menu ---");
    Console.WriteLine("1. Restart Service");
    Console.WriteLine("2. Shutdown");
    userSelection = Convert.ToInt32( Console.ReadLine());

} while (userSelection < 1 || userSelection > 2); // Repeats if input is invalid


//Loop Break and continue
int[] dataPacket = { 10, 20, -1, 40, 999, 50 , 1000, 60 };

foreach (int structure in dataPacket)
{
    if (structure < 0)
    {
        continue; // Skip invalid negative structures, keep processing the rest
    }

    if (structure == 999)
    {
        Console.WriteLine("Critical emergency stop detected.");
        break; // Stop everything immediately
    }

    Console.WriteLine($"Processing safe metric: {structure}");
}