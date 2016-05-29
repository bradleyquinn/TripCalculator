using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BWQ.TripCalculator;
using BWQ.TripCalculator.Models;
using System.Diagnostics;

namespace BWQ.TripCalculator.Service
{
    public class CalculationService
    {
        public NotImplementedException CalculateTotals()
        {
            return new NotImplementedException();
        }
    }

    public class PersistData
    {
        public static void CreateSessionVariables(StudentTraveler currentTraveler, int numUses)
        {
            try
            {
                HttpContext.Current.Session[string.Format("traveler{0}Name", numUses)] = currentTraveler.Name;
                HttpContext.Current.Session[string.Format("traveler{0}FuelFlight", numUses)] = currentTraveler.FuelFlight.ToString();
                HttpContext.Current.Session[string.Format("traveler{0}FoodDrink", numUses)] = currentTraveler.FoodDrink.ToString();
                HttpContext.Current.Session[string.Format("traveler{0}Lodging", numUses)] = currentTraveler.Lodging.ToString();
                HttpContext.Current.Session[string.Format("traveler{0}Activities", numUses)] = currentTraveler.Activites.ToString();
            }
            catch
            {
                Debug.Print("Error creating session variables");
            }
        }
    }
}