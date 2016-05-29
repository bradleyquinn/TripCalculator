using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using BWQ.TripCalculator.Models;

namespace BWQ.TripCalculator
{
    public partial class StudentExpenses : System.Web.UI.Page
    {
        Regex nameValidation = new Regex(@"[A-Za-z. ]+$");
        Regex numericValidation = new Regex(@"[0-9. ]+$");

        protected void Page_Load(object sender, EventArgs e)
        {

            StudentTravelers traveler = new StudentTravelers();

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
                    lblSuccess.Text = string.Format("Congratulations, student {0} successfully added.", tbxName.Text);
                    lblSuccess.Visible = true;
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