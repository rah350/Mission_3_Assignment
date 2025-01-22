// create a system to track food items, monitor expiration dates
// and manage donations and distributions.
using Mission_3_Assignment;

FoodItem fi = new FoodItem();
bool condition = true;

while (condition == true) // Keep the program running in a loop
{
    Console.WriteLine("\nWelcome to the Inventory!");
    Console.WriteLine("\nWhat would you like to do today?");
    Console.WriteLine("1. Add Food Items");
    Console.WriteLine("2. Delete Food Items");
    Console.WriteLine("3. Print List of Current Food Items");
    Console.WriteLine("4. Exit the Program");
    Console.Write("(Enter a number - i.e: 3): ");

    string fakeanswer = Console.ReadLine();
    int answer;
    

    if (!int.TryParse(fakeanswer, out answer))
    {
        Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
        continue; // Restart loop if input is invalid
    }

    Console.WriteLine("You entered: " + answer);

    switch (answer)
    {
        case 1:
            fi.AddFoodItem();
            break;
        case 2:
            fi.RemoveFoodItem();
            break;
        case 3:
            fi.PrintFoodItems();
            break;
        case 4:
            Console.WriteLine("Exiting the program...");
            return; // Exit the program
        default:
            Console.WriteLine("Only 1-4 please :)");
            break;
    }
}

