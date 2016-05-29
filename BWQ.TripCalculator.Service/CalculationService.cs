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
        public static void CreateCookie(HttpCookie studentTraveler, StudentTraveler currentTraveler, int numUses)
        {
            try
            {
                studentTraveler[string.Format("traveler{0}Name", numUses)] = currentTraveler.Name;
                studentTraveler[string.Format("traveler{0}FuelFlight", numUses)] = currentTraveler.FuelFlight.ToString();
                studentTraveler[string.Format("traveler{0}FoodDrink", numUses)] = currentTraveler.FoodDrink.ToString();
                studentTraveler[string.Format("traveler{0}Lodging", numUses)] = currentTraveler.Lodging.ToString();
                studentTraveler[string.Format("traveler{0}Activities", numUses)] = currentTraveler.Activites.ToString();

                studentTraveler.Expires = DateTime.Now.AddHours(4);
                HttpContext.Current.Response.Cookies.Add(studentTraveler);
            }
            catch
            {
                Debug.Print("Error creating cookie value");
            }
        }
    }
}