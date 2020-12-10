using HDM.BL.Enums;
using System;

namespace HDM.BL.Models
{
    public class Beverage
    {
        public Beverage(Water boilingWater, Ingredients ingredient)
        {
            BoilingWater = boilingWater ?? throw new ArgumentNullException(nameof(boilingWater));
            Ingredient = ingredient;
        }

        public Water BoilingWater { get; set; }

        public Ingredients Ingredient { get; set; }
    }
}