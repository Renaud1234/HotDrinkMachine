using HDM.BL.Enums;
using HDM.BL.Models;
using System;
using System.Threading.Tasks;

namespace HDM.BL.Services
{
    public interface IHotDrinkService
    {
        event EventHandler<string> WriteEvent;

        Task<Cup> AddCondiment(Cup cup, Ingredients ingredient);

        Task<Water> BoilWater();

        Task<Beverage> Mix(Water boilingWater, Ingredients ingredient);

        Task<Cup> PourInCup(Beverage beverage);
    }
}