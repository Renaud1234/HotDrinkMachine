using HDM.BL.Enums;
using System.Collections.Generic;

namespace HDM.BL.Models
{
    public class Cup
    {
        public Cup()
        {
            Condiments = new HashSet<Ingredients>();
        }

        public Beverage Beverage { get; set; }

        public HashSet<Ingredients> Condiments { get; set; }
    }
}