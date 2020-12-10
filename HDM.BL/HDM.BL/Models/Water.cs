namespace HDM.BL.Models
{
    public class Water
    {
        public Water()
        {
            Name = "Water";
            TimeToBoil = 2;
        }

        public string Name { get; set; }
        public int Temperature { get; set; }
        public int TimeToBoil { get; set; }
    }
}