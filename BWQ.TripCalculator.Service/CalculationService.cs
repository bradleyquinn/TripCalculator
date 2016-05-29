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
                HttpContext.Current.Session[string.Format("traveler{0}Name:{1}", numUses, currentTraveler.Name)] = currentTraveler.Name;
                HttpContext.Current.Session[string.Format("traveler{0}FuelFlight:{1}", numUses, currentTraveler.FuelFlight.ToString())] = currentTraveler.FuelFlight.ToString();
                HttpContext.Current.Session[string.Format("traveler{0}FoodDrink:{1}", numUses, currentTraveler.FoodDrink.ToString())] = currentTraveler.FoodDrink.ToString();
                HttpContext.Current.Session[string.Format("traveler{0}Lodging:{1}", numUses, currentTraveler.Lodging.ToString())] = currentTraveler.Lodging.ToString();
                HttpContext.Current.Session[string.Format("traveler{0}Activities:{1}", numUses, currentTraveler.Activites.ToString())] = currentTraveler.Activites.ToString();
            }
            catch (Exception ex)
            {
                Debug.Print(string.Format("Error creating session variables. {0}", ex));
            }
        }
    }

    public class RetrieveData
    {
        //return list of strings we know there are 5 values per traveler
        public static List<string> RetrieveSessionVariables()
        {
            List<string> travelerList = new List<string>();

            try
            {
                foreach(string sessionTraveler in HttpContext.Current.Session.Keys)
                {
                    if (!sessionTraveler.Contains("numUses"))
                    {
                        travelerList.Add(sessionTraveler.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print(string.Format("Error retrieving session variables. {0}", ex));
            }

            return travelerList;
        }
    }
}