using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using BWQ.TripCalculator.Service;
using BWQ.TripCalculator.Models;

namespace BWQ.TripCalculator
{
    public partial class StudentExpenses : System.Web.UI.Page
    {
        int numUses;
        Regex nameValidation = new Regex(@"[A-Za-z. ]+$");
        Regex numericValidation = new Regex(@"[0-9. ]+$");
        HttpCookie travelerCookie = new HttpCookie("travelerCookie");
        StudentTraveler currentTraveler = new StudentTraveler();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["numUses"] == null)
                numUses = 1;
            else
            {
                numUses = (int)Session["numUses"];
                numUses++;
            }

            ResetErrorMessaging();
        }

        private void ResetErrorMessaging()
        {
            if (lblEmptyError.Visible)
                lblEmptyError.Visible = false;

            if (lblNameError.Visible)
                lblNameError.Visible = false;

            if (lblNumericError.Visible)
                lblNumericError.Visible = false;
        }

        private void ClearForm()
        {
            tbxName.Text =
                tbxFuel.Text =
                tbxFood.Text =
                tbxLodging.Text =
                tbxActivities.Text = string.Empty;
        }

        private bool RegexNameValidation()
        {
            Match nameMatch = Regex.Match(tbxName.Text.Trim(), nameValidation.ToString());

            if (nameMatch.Success)
            {
                return true;
            }

            return false;
        }

        private bool RegexNumericValidation()
        {
            Match fuelMatch = Regex.Match(tbxFuel.Text.Trim(), numericValidation.ToString());
            Match foodMatch = Regex.Match(tbxFood.Text.Trim(), numericValidation.ToString());
            Match lodgingMatch = Regex.Match(tbxLodging.Text.Trim(), numericValidation.ToString());
            Match activityMatch = Regex.Match(tbxActivities.Text.Trim(), numericValidation.ToString());

            if (fuelMatch.Success &&
                foodMatch.Success &&
                lodgingMatch.Success &&
                activityMatch.Success)
            {
                return true;
            }

            return false;
        }

        private bool HasEmptyFields()
        {
            if (string.IsNullOrWhiteSpace(tbxName.Text) ||
                string.IsNullOrWhiteSpace(tbxFuel.Text) ||
                string.IsNullOrWhiteSpace(tbxFood.Text) ||
                string.IsNullOrWhiteSpace(tbxLodging.Text) ||
                string.IsNullOrWhiteSpace(tbxActivities.Text))
            {
                return true;
            }

            return false;
        }

        private void CreateCookie(StudentTraveler currentTraveler, int numUses)
        {
            PersistData.CreateCookie(travelerCookie, currentTraveler, numUses);
        }

        private StudentTraveler FillMainObject()
        {
            currentTraveler.Name = tbxName.Text;
            currentTraveler.FuelFlight = Convert.ToDouble(tbxFuel.Text);
            currentTraveler.FoodDrink = Convert.ToDouble(tbxFood.Text);
            currentTraveler.Lodging = Convert.ToDouble(tbxLodging.Text);
            currentTraveler.Activites = Convert.ToDouble(tbxActivities.Text);

            return currentTraveler;
        }

        protected void btnAnother_Click(object sender, EventArgs e)
        {
            bool regexNamePass = RegexNameValidation();
            bool regexNumericPass = RegexNumericValidation();
            bool isEmptyField = HasEmptyFields();

            if (isEmptyField)
            {
                lblEmptyError.Visible = true;
            }
            else
            {
                if (regexNamePass && regexNumericPass)
                {
                    lblSuccess.Text = string.Format("Congratulations, traveler {0} successfully added.", tbxName.Text);
                    lblSuccess.Visible = true;
                    StudentTraveler _mainObj = FillMainObject();
                    CreateCookie(_mainObj, numUses);
                    ClearForm();
                    Session.Add("numUses", numUses);
                }
                else
                {
                    if (!regexNamePass)
                    {
                        lblNameError.Visible = true;
                    }

                    if (!regexNumericPass)
                    {
                        lblNumericError.Visible = true;

                        if (!regexNamePass)
                        {
                            lblNumericError.CssClass = "alert alert-danger doublemessage";
                        }
                    }
                }
            }
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            bool regexNamePass = RegexNameValidation();
            bool regexNumericPass = RegexNumericValidation();
            bool isEmptyField = HasEmptyFields();

            if (isEmptyField)
            {
                lblEmptyError.Visible = true;
            }
            else
            {
                if (regexNamePass && regexNumericPass)
                {
                    Response.Redirect("~/StudentPayout.aspx");
                }
                else
                {
                    if (!regexNamePass)
                    {
                        lblNameError.Visible = true;
                    }

                    if (!regexNumericPass)
                    {
                        lblNumericError.Visible = true;

                        if (!regexNamePass)
                        {
                            lblNumericError.CssClass = "alert alert-danger doublemessage";
                        }
                    }
                }
            }
        }
    }
}