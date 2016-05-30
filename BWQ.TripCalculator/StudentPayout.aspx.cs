using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BWQ.TripCalculator.Models;
using BWQ.TripCalculator.Service;

namespace BWQ.TripCalculator
{
    public partial class StudentPayout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> currentTravelers = RetrieveSession();
            List<string> cleanTravelers = CleanData(currentTravelers);
            List<TravelerTotals> totals = AssignTotals(cleanTravelers);
            List<TravelerTotals> owingTravelers = CalculationService.CalculateTotals(totals);


        }

        private List<string> RetrieveSession()
        {
            List<string> travelerList = RetrieveData.RetrieveSessionVariables();

            return travelerList;
        }

        private List<string> CleanData(List<string> currentTravelers)
        {
            List<string> cleanTravelers = new List<string>();
            char delimiter = ':';

            foreach (string dirtyString in currentTravelers)
            {
                string[] split = dirtyString.Split(delimiter);
                cleanTravelers.Add(split[1]);
            }

            return cleanTravelers;
        }

        private List<TravelerTotals> AssignTotals(List<string> cleanTravelers)
        {
            List<TravelerTotals> totals = new List<TravelerTotals>(cleanTravelers.Count / 5);

            int skipValue = 0;

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

            return totals;
        }
    }
}