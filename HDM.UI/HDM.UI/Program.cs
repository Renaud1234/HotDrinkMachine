using HDM.BL.Models;
using HDM.BL.Services;
using System;

namespace HDM.UI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hello dear customer!");

                // Get customer choice
                Console.WriteLine("What will be your hot drink today?");
                Console.WriteLine("1 - Lemon Tea");
                Console.WriteLine("2 - Coffee");
                Console.WriteLine("3 - Chocolate");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int customerChoice))
                {
                    // Make hot drink
                    HotDrinkService hotDrinkService = new HotDrinkService();
                    HotDrinkPreparation hotDrinkPreparation = new HotDrinkPreparation(hotDrinkService);
                    Cup cup = hotDrinkPreparation.Prepare(customerChoice).GetAwaiter().GetResult();

                    if (cup == null)
                    {
                        Console.WriteLine("Sorry, this drink is unavailable!");
                    }
                    else
                    {
                        Console.WriteLine($"Your {cup.Beverage.Ingredient} is ready!");
                        Console.WriteLine("---> Take care it's hot <---");
                    }
                    Console.ReadKey();
                }
            }
        }
    }
}