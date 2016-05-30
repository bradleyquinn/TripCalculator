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
        public static List<TravelerTotals> CalculateTotals(List<TravelerTotals> totals)
        {
            double tripTotal = totals.Sum(x => x.Total);
            double eachOwes = tripTotal / totals.Count;
            List<TravelerTotals> owingTravelers = DetermineWhoOwes(totals, tripTotal, eachOwes);

            return owingTravelers;
        }

        private static List<TravelerTotals> DetermineWhoOwes(List<TravelerTotals> totals, double tripTotal, double eachOwes)
        {
            List<string> names = new List<string>(totals.Count);
            List<double> paidOut = new List<double>(totals.Count);

            try
            {
                for (int i = 0; i < totals.Count; i++)
                {
                    names.Add(totals[i].Name);
                    paidOut.Add(totals[i].Total);
                }

                for (int i = 0; i < paidOut.Count; i++)
                {
                    if (paidOut[i] < eachOwes)
                    {
                        totals[i].Owes = true;
                        totals[i].AmountOwes = eachOwes - paidOut[i];
                    }
                    else if (paidOut[i] > eachOwes)
                    {
                        totals[i].IsOwed = true;
                        totals[i].AmountOwed = paidOut[i] - eachOwes;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print(string.Format("Error calculating who owes. {0}", ex));
            }

            return totals;
        }

        public static List<TravelerTotals> AssignTotals(List<string> cleanTravelers)
        {
            List<TravelerTotals> totals = new List<TravelerTotals>(cleanTravelers.Count / 5);

            int skipValue = 0;

            try
            {
                for (int i = 0; i < cleanTravelers.Count / 5; i++)
                {
                    totals.Add(new TravelerTotals());

                    totals[i].Name = cleanTravelers[i + skipValue];

                    totals[i].Total = Convert.ToDouble(cleanTravelers[1 + i + skipValue]) +
                        Convert.ToDouble(cleanTravelers[2 + i + skipValue]) +
                        Convert.ToDouble(cleanTravelers[3 + i + skipValue]) +
                        Convert.ToDouble(cleanTravelers[4 + i + skipValue]);

                    skipValue += 4;
                }
            }
            catch (Exception ex)
            {
                Debug.Print(string.Format("Error assigning totals. {0}", ex));
            }

            return totals;
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
        public static List<string> RetrieveSessionVariables()
        {
            List<string> travelerList = new List<string>();

            try
            {
                foreach (string sessionTraveler in HttpContext.Current.Session.Keys)
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

    public class CleanseData
    {
        public static List<string> CleanData(List<string> currentTravelers)
        {
            List<string> cleanTravelers = new List<string>();
            char delimiter = ':';

            try
            {
                foreach (string dirtyString in currentTravelers)
                {
                    string[] split = dirtyString.Split(delimiter);
                    cleanTravelers.Add(split[1]);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(string.Format("Error cleansing data. {0}", ex));
            }

            return cleanTravelers;
        }
    }
}