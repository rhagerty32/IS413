using System;

namespace DiceRollingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the dice throwing simulator!");

            // Get the number of rolls from the user
            Console.Write("How many dice rolls would you like to simulate? ");
            if (!int.TryParse(Console.ReadLine(), out int numRolls) || numRolls <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                return;
            }

            // Simulate the dice rolls
            DiceRoller diceRoller = new DiceRoller();
            int[] rollResults = diceRoller.SimulateRolls(numRolls);

            // Display the results
            Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
            Console.WriteLine($"Total number of rolls = {numRolls}.\n");

            for (int i = 2; i <= 12; i++)
            {
                double percentage = (rollResults[i] / (double)numRolls) * 100;
                int stars = (int)Math.Round(percentage); // Convert percentage to asterisk count
                Console.WriteLine($"{i}: {new string('*', stars)}");
            }

            Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
        }
    }

    // Class to handle dice-rolling logic
    class DiceRoller
    {
        private Random _random;

        public DiceRoller()
        {
            _random = new Random();
        }

        public int[] SimulateRolls(int numRolls)
        {
            // Array to store counts for each possible roll (2 to 12)
            int[] rollCounts = new int[13];

            for (int i = 0; i < numRolls; i++)
            {
                int die1 = RollDie();
                int die2 = RollDie();
                int sum = die1 + die2;

                rollCounts[sum]++;
            }

            return rollCounts;
        }

        private int RollDie()
        {
            // Simulate rolling a 6-sided die (returns a value between 1 and 6)
            return _random.Next(1, 7);
        }
    }
}