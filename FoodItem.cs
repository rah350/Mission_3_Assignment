using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission_3_Assignment
{
    internal class FoodItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public DateOnly ExpirationDate { get; set; }

        private List<FoodItem> FoodItems = new List<FoodItem>(); // needs to be a non-static list. 
        public void AddFoodItem()
        {
            Console.Write("\nHow many food items would you like to add? (Enter a number): ");
            if (!int.TryParse(Console.ReadLine(), out int answer) || answer <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            for (int i = 0; i < answer; i++)
            {
                FoodItem item = new FoodItem();

                Console.Write("Name of Item " + ( i + 1 ) + ": ");
                item.Name = Console.ReadLine();

                Console.Write("Category of Item " + ( i + 1 ) + " (e.g., Canned Goods, Dairy, Produce): ");
                item.Category = Console.ReadLine();

                // declares a temporary variable for parsing quantity
                int quantityInput;
                Console.Write("Quantity (e.g., 4, 32): ");
                while (!int.TryParse(Console.ReadLine(), out quantityInput) || quantityInput <= 0)
                {
                    Console.Write("Invalid quantity. Please enter a positive number: ");
                }
                item.Quantity = quantityInput; // assign parsed value to the item property

                //  declares a temporary variable for parsing exp date
                DateOnly expirationInput;
                Console.Write("Expiration Date (yyyy-MM-dd): ");
                while (!DateOnly.TryParse(Console.ReadLine(), out expirationInput))
                {
                    Console.Write("Invalid date format. Please enter a date in yyyy-MM-dd format: ");
                }
                item.ExpirationDate = expirationInput; // assign parsed value to the item property

                FoodItems.Add(item);
            }
        }
        public void PrintFoodItems()
        {
            if (FoodItems.Count == 0)
            {
                Console.WriteLine("No food items in the inventory.");
                return;
            }

            Console.WriteLine("\nCurrent Food Inventory:");
            foreach (var food in FoodItems)
            {
                Console.WriteLine($"- {food.Name}: \n\tCategory: {food.Category}\n\tQuantity: {food.Quantity} \n\tExpiration: {food.ExpirationDate}");
            }
        }

        public void RemoveFoodItem()
        {
            if (FoodItems.Count == 0)
            {
                Console.WriteLine("No food items in the inventory to remove.");
                return;
            }

            Console.WriteLine("\nCurrent Food Inventory: ");
            for (int i = 0; i < FoodItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {FoodItems[i].Name} - {FoodItems[i].Category}, Quantity: {FoodItems[i].Quantity}, Expiration: {FoodItems[i].ExpirationDate}");
            }

            Console.WriteLine("\nEnter the number of the item you wish to delete: ");
            if(int.TryParse(Console.ReadLine(), out int itemNumber) && itemNumber > 0 && itemNumber <= FoodItems.Count)
            {
                Console.WriteLine($"Removing {FoodItems[itemNumber - 1].Name}...");
                FoodItems.RemoveAt(itemNumber - 1);
                Console.WriteLine("Item removed successfully!");
            }
            else
            {
                Console.WriteLine("Invalid Selection. Please enter a valid number.");
            }
        }
    }
}