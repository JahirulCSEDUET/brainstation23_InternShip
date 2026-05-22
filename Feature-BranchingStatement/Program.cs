//BranchingStatement- if else
int userAge = 16;

if (userAge >= 18)
{
    Console.WriteLine("Eligible for full driver's license.");
}
else if (userAge >= 15)
{
    Console.WriteLine("Eligible for learner's permit.");
}
else
{
    Console.WriteLine("Too young to drive.");
}
//BranchingStatement - switch/classic
string userRole = "Admin";

switch (userRole)
{
    case "Admin":
        Console.WriteLine("Full access granted.");
        break;
    case "Manager":
        Console.WriteLine("Limited modification access granted.");
        break;
    case "Guest":
        Console.WriteLine("Read-only access granted.");
        break;
    default:
        Console.WriteLine("Access denied: Invalid role.");
        break;
}
//BranchingStatement - switch/modern
string accessArea = userRole switch
{
    "Admin" => "Full access granted.",
    "Manager" => "Limited modification access granted.",
    "Guest" => "Read-only access granted.",
    _ => "Access denied: Invalid role."
};
Console.WriteLine(accessArea);