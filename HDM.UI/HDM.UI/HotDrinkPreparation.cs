using HDM.BL.Enums;
using HDM.BL.Models;
using HDM.BL.Services;
using System;
using System.Threading.Tasks;

namespace HDM.UI
{
    public class HotDrinkPreparation
    {
        private readonly IHotDrinkService _hotDrinkService;

        public HotDrinkPreparation(IHotDrinkService hotDrinkService)
        {
            _hotDrinkService = hotDrinkService ?? throw new ArgumentNullException(nameof(hotDrinkService));
        }

        internal async Task<Cup> Prepare(int customerChoice)
        {
            _hotDrinkService.WriteEvent += WriteEvent;

            return customerChoice switch
            {
                1 => await PrepareLemonTea(),
                2 => await PrepareCoffee(),
                3 => await PrepareChocolate(),
                _ => null,
            };
        }

        private async Task<Cup> PrepareLemonTea()
        {
            Ingredients hotDrink = Ingredients.Tea;
            Ingredients[] condiments = new Ingredients[] { Ingredients.Lemon };

            return await GenericPreparation(hotDrink, condiments);
        }

        private async Task<Cup> PrepareCoffee()
        {
            Ingredients hotDrink = Ingredients.Coffee;
            Ingredients[] condiments = new Ingredients[]
            {
                Ingredients.Sugar,
                Ingredients.Milk
            };

            return await GenericPreparation(hotDrink, condiments);
        }

        private async Task<Cup> PrepareChocolate()
        {
            Ingredients hotDrink = Ingredients.Chocolate;
            Ingredients[] condiments = new Ingredients[] { };

            return await GenericPreparation(hotDrink, condiments);
        }

        private async Task<Cup> GenericPreparation(Ingredients hotDrink, Ingredients[] condiments)
        {
            // Boil some water
            Water boilingWater = await _hotDrinkService.BoilWater();

            // Steep the water in the tea
            Beverage beverage = await _hotDrinkService.Mix(boilingWater, hotDrink);

            // Pour tea in the cup
            Cup cup = await _hotDrinkService.PourInCup(beverage);

            // Add lemon
            foreach (var condiment in condiments)
            {
                cup = await _hotDrinkService.AddCondiment(cup, condiment);
            }

            return cup;
        }

        // Event handler
        public static void WriteEvent(object sender, string eventArgs)
        {
            Console.WriteLine(eventArgs);
        }
    }
}