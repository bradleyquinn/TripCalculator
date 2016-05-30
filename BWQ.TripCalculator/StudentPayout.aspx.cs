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
            List<string> cleanTravelers = CleanseData.CleanData(currentTravelers);
            List<TravelerTotals> totals = CalculationService.AssignTotals(cleanTravelers);
            List<TravelerTotals> owingTravelers = CalculationService.CalculateTotals(totals);

            CreateDisplay(owingTravelers);

            Session.Abandon();
        }

        private void CreateDisplay(List<TravelerTotals> owingTravelers)
        {
            int owedCount = 0;

            foreach (var count in owingTravelers)
            {
                if (count.IsOwed)
                    owedCount++;
            }

            foreach (var display in owingTravelers)
            {                                             
                if (display.Owes)
                {                    
                    lblOwes.Text += string.Format("{0}: <b>owes</b> {1} total, {2}", 
                        display.Name, Math.Round(display.AmountOwes, 2), 
                        owedCount > 1 ? string.Format("divided amongst {0} travelers. <br />", owedCount) : "to 1 traveler. <br />");
                }

                if (display.IsOwed)
                {
                    lblOwed.Text += string.Format("{0}: is <b>owed</b> {1} total. <br />", display.Name, display.AmountOwed);
                }
            }
        }

        private List<string> RetrieveSession()
        {
            List<string> travelerList = RetrieveData.RetrieveSessionVariables();

            return travelerList;
        }
    }
}