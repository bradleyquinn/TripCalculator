using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BWQ.TripCalculator;

namespace BWQ.TripCalculator.Models
{
    public class StudentTraveler
    { 
        public string Name { get; set; }
        public double FuelFlight { get; set; }
        public double FoodDrink { get; set; }
        public double Lodging { get; set; }
        public double Activites { get; set; }
    }

    public class TravelerTotals
    {
        public string Name { get; set; }
        public double Total { get; set; }
        public bool Owes { get; set; }
        public double AmountOwed { get; set; }
    }
}