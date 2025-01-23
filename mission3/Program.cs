using System;
using System.Collections.Generic;

namespace FoodBankInventorySystem
{
    class Program
    {
        // List to store all food items
        static List<FoodItem> _foodItems = new List<FoodItem>();

        // Handle inputs
        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();

                string choice = Console.ReadLine();
                Console.Clear();
                
                switch (choice)
                {
                    case "1":
                        AddFoodItem();
                        break;
                    case "2":
                        DeleteFoodItem();
                        break;
                    case "3":
                        PrintFoodItems();
                        break;
                    case "4":
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.\n");
                        break;
                }
            }
        }

        // Display the menu options
        static void ShowMenu()
        {
            Console.WriteLine("Food Bank Inventory System");
            Console.WriteLine("1. Add Food Item");
            Console.WriteLine("2. Delete Food Item");
            Console.WriteLine("3. Print List of Current Food Items");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
        }

        // Add a new food item to the inventory
        static void AddFoodItem()
        {
            try
            {
                Console.Write("Enter food name: ");
                string name = Console.ReadLine();

                Console.Write("Enter category (e.g., Canned Goods, Dairy, Produce): ");
                string category = Console.ReadLine();

                Console.Write("Enter quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
                {
                    Console.WriteLine("Invalid quantity. It must be a non-negative integer.\n");
                    return;
                }

                Console.Write("Enter expiration date (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime expirationDate))
                {
                    Console.WriteLine("Invalid date format. Please try again.\n");
                    return;
                }

                _foodItems.Add(new FoodItem(name, category, quantity, expirationDate));
                Console.WriteLine("Food item added successfully!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\n");
            }
        }

        // Delete a food item from the inventory
        static void DeleteFoodItem()
        {
            if (_foodItems.Count == 0)
            {
                Console.WriteLine("No food items to delete.\n");
                return;
            }

            Console.WriteLine("Enter the number of the food item you want to delete:");
            PrintFoodItems();

            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > _foodItems.Count)
            {
                Console.WriteLine("Invalid choice. Please try again.\n");
                return;
            }

            _foodItems.RemoveAt(index - 1);
            Console.WriteLine("Food item deleted successfully!\n");
        }

        // Print the list of all food items in the inventory
        static void PrintFoodItems()
        {
            if (_foodItems.Count == 0)
            {
                Console.WriteLine("No food items in inventory.\n");
                return;
            }

            Console.WriteLine("Current Food Items:");
            for (int i = 0; i < _foodItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_foodItems[i]}");
            }
            Console.WriteLine();
        }
    }
}