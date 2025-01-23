using System;

namespace FoodBankInventorySystem
{
    public class FoodItem
    {
        // Properties of the food item
        public string Name { get; private set; }
        public string Category { get; private set; }
        public int Quantity { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        // Constructor to initialize a food item
        public FoodItem(string name, string category, int quantity, DateTime expirationDate)
        {
            Name = name;
            Category = category;
            Quantity = quantity >= 0 ? quantity : throw new ArgumentException("Quantity cannot be negative.");
            ExpirationDate = expirationDate;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Category: {Category}, Quantity: {Quantity}, Expiration Date: {ExpirationDate:yyyy-MM-dd}";
        }
    }
}