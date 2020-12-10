using HDM.BL.Enums;
using HDM.BL.Models;
using System;
using System.Threading.Tasks;

namespace HDM.BL.Services
{
    public class HotDrinkService : IHotDrinkService
    {
        public event EventHandler<string> WriteEvent;

        protected virtual void OnEvent(string eventArgs)
        {
            WriteEvent?.Invoke(this, eventArgs);
        }

        public async Task<Cup> AddCondiment(Cup cup, Ingredients ingredient)
        {
            //Console.WriteLine($"Add {ingredient}.");
            OnEvent($"Add {ingredient}");
            await Task.Delay(1000);
            cup.Condiments.Add(ingredient);
            return cup;
        }

        public async Task<Water> BoilWater()
        {
            OnEvent("Boil Water");

            Water water = new Water();

            await Task.Delay(water.TimeToBoil * 1000);
            water.Temperature = 100;

            return water;
        }

        public async Task<Beverage> Mix(Water boilingWater, Ingredients ingredient)
        {
            OnEvent($"Mix {boilingWater.Name} with {ingredient}");
            await Task.Delay(1000);
            return new Beverage(boilingWater, ingredient);
        }

        public async Task<Cup> PourInCup(Beverage beverage)
        {
            Cup cup = new Cup();
            OnEvent($"Pour {beverage.Ingredient} in cup");
            await Task.Delay(2000);
            cup.Beverage = beverage;
            return cup;
        }
    }
}