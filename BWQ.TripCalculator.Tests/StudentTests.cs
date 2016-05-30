using System;
using NUnit.Framework;
using BWQ.TripCalculator.Service;
using BWQ.TripCalculator.Models;
using BWQ.TripCalculator;
using System.Collections.Generic;
using System.Web;

namespace BWQ.TripCalculator.Tests
{
    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void CaculateTotalsTest01()
        {
            List<TravelerTotals> testTotals = new List<TravelerTotals>();

            testTotals.Add(new TravelerTotals());
            testTotals[0].Name = "BeeRad";
            testTotals[0].Total = 1000;

            testTotals.Add(new TravelerTotals());
            testTotals[1].Name = "Rachel";
            testTotals[1].Total = 2000;

            List<TravelerTotals> owingTotals = CalculationService.CalculateTotals(testTotals);

            Assert.AreEqual(testTotals[0].AmountOwed, 0);
            Assert.AreEqual(testTotals[0].AmountOwes, 500);
            Assert.AreEqual(testTotals[0].IsOwed, false);
            Assert.AreEqual(testTotals[0].Owes, true);

            Assert.AreEqual(testTotals[1].AmountOwed, 500);
            Assert.AreEqual(testTotals[1].AmountOwes, 0);
            Assert.AreEqual(testTotals[1].IsOwed, true);
            Assert.AreEqual(testTotals[1].Owes, false);
        }

        [Test]
        public void CalculateTotalsTest02()
        {
            List<TravelerTotals> testTotals = new List<TravelerTotals>();

            testTotals.Add(new TravelerTotals());
            testTotals[0].Name = "BeeRad";
            testTotals[0].Total = 1000;

            testTotals.Add(new TravelerTotals());
            testTotals[1].Name = "Rachel";
            testTotals[1].Total = 2000;

            testTotals.Add(new TravelerTotals());
            testTotals[2].Name = "Shawn";
            testTotals[2].Total = 3000;

            testTotals.Add(new TravelerTotals());
            testTotals[3].Name = "Skye";
            testTotals[3].Total = 4000;

            List<TravelerTotals> owingTotals = CalculationService.CalculateTotals(testTotals);

            Assert.AreEqual(testTotals[0].AmountOwed, 0);
            Assert.AreEqual(testTotals[0].AmountOwes, 1500);
            Assert.AreEqual(testTotals[0].IsOwed, false);
            Assert.AreEqual(testTotals[0].Owes, true);

            Assert.AreEqual(testTotals[1].AmountOwed, 0);
            Assert.AreEqual(testTotals[1].AmountOwes, 500);
            Assert.AreEqual(testTotals[1].IsOwed, false);
            Assert.AreEqual(testTotals[1].Owes, true);

            Assert.AreEqual(testTotals[2].AmountOwed, 500);
            Assert.AreEqual(testTotals[2].AmountOwes, 0);
            Assert.AreEqual(testTotals[2].IsOwed, true);
            Assert.AreEqual(testTotals[2].Owes, false);

            Assert.AreEqual(testTotals[3].AmountOwed, 1500);
            Assert.AreEqual(testTotals[3].AmountOwes, 0);
            Assert.AreEqual(testTotals[3].IsOwed, true);
            Assert.AreEqual(testTotals[3].Owes, false);
        }

        [Test]
        public void CalculateTotalsTest03()
        {
            List<TravelerTotals> testTotals = new List<TravelerTotals>();

            testTotals.Add(new TravelerTotals());
            testTotals[0].Name = "BeeRad";
            testTotals[0].Total = 1000;

            testTotals.Add(new TravelerTotals());
            testTotals[1].Name = "Rachel";
            testTotals[1].Total = 2000;

            testTotals.Add(new TravelerTotals());
            testTotals[2].Name = "Shawn";
            testTotals[2].Total = 3000;

            testTotals.Add(new TravelerTotals());
            testTotals[3].Name = "Skye";
            testTotals[3].Total = 4000;

            testTotals.Add(new TravelerTotals());
            testTotals[4].Name = "Loren";
            testTotals[4].Total = 5000;

            testTotals.Add(new TravelerTotals());
            testTotals[5].Name = "Zach";
            testTotals[5].Total = 6000;

            List<TravelerTotals> owingTotals = CalculationService.CalculateTotals(testTotals);

            Assert.AreEqual(testTotals[0].AmountOwed, 0);
            Assert.AreEqual(testTotals[0].AmountOwes, 2500);
            Assert.AreEqual(testTotals[0].IsOwed, false);
            Assert.AreEqual(testTotals[0].Owes, true);

            Assert.AreEqual(testTotals[1].AmountOwed, 0);
            Assert.AreEqual(testTotals[1].AmountOwes, 1500);
            Assert.AreEqual(testTotals[1].IsOwed, false);
            Assert.AreEqual(testTotals[1].Owes, true);

            Assert.AreEqual(testTotals[2].AmountOwed, 0);
            Assert.AreEqual(testTotals[2].AmountOwes, 500);
            Assert.AreEqual(testTotals[2].IsOwed, false);
            Assert.AreEqual(testTotals[2].Owes, true);

            Assert.AreEqual(testTotals[3].AmountOwed, 500);
            Assert.AreEqual(testTotals[3].AmountOwes, 0);
            Assert.AreEqual(testTotals[3].IsOwed, true);
            Assert.AreEqual(testTotals[3].Owes, false);

            Assert.AreEqual(testTotals[4].AmountOwed, 1500);
            Assert.AreEqual(testTotals[4].AmountOwes, 0);
            Assert.AreEqual(testTotals[4].IsOwed, true);
            Assert.AreEqual(testTotals[4].Owes, false);

            Assert.AreEqual(testTotals[5].AmountOwed, 2500);
            Assert.AreEqual(testTotals[5].AmountOwes, 0);
            Assert.AreEqual(testTotals[5].IsOwed, true);
            Assert.AreEqual(testTotals[5].Owes, false);
        }

        [Test]
        public void CalculateTotalsTest04()
        {
            List<TravelerTotals> testTotals = new List<TravelerTotals>();

            testTotals.Add(new TravelerTotals());
            testTotals[0].Name = "BeeRad";
            testTotals[0].Total = 1000.50;

            testTotals.Add(new TravelerTotals());
            testTotals[1].Name = "Rachel";
            testTotals[1].Total = 2000.67;

            testTotals.Add(new TravelerTotals());
            testTotals[2].Name = "Shawn";
            testTotals[2].Total = 3000.33;

            testTotals.Add(new TravelerTotals());
            testTotals[3].Name = "Skye";
            testTotals[3].Total = 4000.54;

            testTotals.Add(new TravelerTotals());
            testTotals[4].Name = "Loren";
            testTotals[4].Total = 5000.13;

            testTotals.Add(new TravelerTotals());
            testTotals[5].Name = "Zach";
            testTotals[5].Total = 6000.69;

            List<TravelerTotals> owingTotals = CalculationService.CalculateTotals(testTotals);

            Assert.AreEqual(testTotals[0].AmountOwed, 0);
            Assert.AreEqual(Math.Round(testTotals[0].AmountOwes, 2), 2499.98);
            Assert.AreEqual(testTotals[0].IsOwed, false);
            Assert.AreEqual(testTotals[0].Owes, true);

            Assert.AreEqual(testTotals[1].AmountOwed, 0);
            Assert.AreEqual(Math.Round(testTotals[1].AmountOwes, 2), 1499.81);
            Assert.AreEqual(testTotals[1].IsOwed, false);
            Assert.AreEqual(testTotals[1].Owes, true);

            Assert.AreEqual(testTotals[2].AmountOwed, 0);
            Assert.AreEqual(Math.Round(testTotals[2].AmountOwes, 2), 500.15);
            Assert.AreEqual(testTotals[2].IsOwed, false);
            Assert.AreEqual(testTotals[2].Owes, true);

            Assert.AreEqual(Math.Round(testTotals[3].AmountOwed, 2), 500.06);
            Assert.AreEqual(testTotals[3].AmountOwes, 0);
            Assert.AreEqual(testTotals[3].IsOwed, true);
            Assert.AreEqual(testTotals[3].Owes, false);

            Assert.AreEqual(Math.Round(testTotals[4].AmountOwed, 2), 1499.65);
            Assert.AreEqual(testTotals[4].AmountOwes, 0);
            Assert.AreEqual(testTotals[4].IsOwed, true);
            Assert.AreEqual(testTotals[4].Owes, false);

            Assert.AreEqual(Math.Round(testTotals[5].AmountOwed, 2), 2500.21);
            Assert.AreEqual(testTotals[5].AmountOwes, 0);
            Assert.AreEqual(testTotals[5].IsOwed, true);
            Assert.AreEqual(testTotals[5].Owes, false);
        }

        [Test]
        public void AssignTotalsTest01()
        {
            List<string> stringTravelers = new List<string>();

            stringTravelers.Add("BeeRad");
            stringTravelers.Add("100");
            stringTravelers.Add("200");
            stringTravelers.Add("300");
            stringTravelers.Add("400");

            stringTravelers.Add("Rachel");
            stringTravelers.Add("200");
            stringTravelers.Add("300");
            stringTravelers.Add("400");
            stringTravelers.Add("500");

            List<TravelerTotals> totals = CalculationService.AssignTotals(stringTravelers);

            Assert.AreEqual(totals[0].Name, "BeeRad");
            Assert.AreEqual(totals[0].Total, 1000);

            Assert.AreEqual(totals[1].Name, "Rachel");
            Assert.AreEqual(totals[1].Total, 1400);
        }

        [Test]
        public void AssignTotalsTest02()
        {
            List<string> stringTravelers = new List<string>();

            stringTravelers.Add("BeeRad");
            stringTravelers.Add("100.12");
            stringTravelers.Add("200.15");
            stringTravelers.Add("300.45");
            stringTravelers.Add("400.34");

            stringTravelers.Add("Rachel");
            stringTravelers.Add("200.25");
            stringTravelers.Add("300.35");
            stringTravelers.Add("400.54");
            stringTravelers.Add("500.34");

            stringTravelers.Add("Shawn");
            stringTravelers.Add("300.54");
            stringTravelers.Add("200.45");
            stringTravelers.Add("500.76");
            stringTravelers.Add("200.34");

            stringTravelers.Add("Skye");
            stringTravelers.Add("100.34");
            stringTravelers.Add("500.24");
            stringTravelers.Add("400.98");
            stringTravelers.Add("500.24");

            List<TravelerTotals> totals = CalculationService.AssignTotals(stringTravelers);

            Assert.AreEqual(totals[0].Name, "BeeRad");
            Assert.AreEqual(Math.Round(totals[0].Total, 2), 1001.06);

            Assert.AreEqual(totals[1].Name, "Rachel");
            Assert.AreEqual(Math.Round(totals[1].Total, 2), 1401.48);

            Assert.AreEqual(totals[2].Name, "Shawn");
            Assert.AreEqual(Math.Round(totals[2].Total, 2), 1202.09);

            Assert.AreEqual(totals[3].Name, "Skye");
            Assert.AreEqual(Math.Round(totals[3].Total, 2), 1501.80);
        }

        [Test]
        public void CleanseDataTest01()
        {
            List<string> dirtyTravelers = new List<string>();

            dirtyTravelers.Add("Name:BeeRad");
            dirtyTravelers.Add("FuelFlight:100");
            dirtyTravelers.Add("FoodDrink:200");
            dirtyTravelers.Add("Lodging:300");
            dirtyTravelers.Add("Activites:400");

            dirtyTravelers.Add("Name:Rachel");
            dirtyTravelers.Add("FuelFlight:200");
            dirtyTravelers.Add("FoodDrink:300");
            dirtyTravelers.Add("Lodging:400");
            dirtyTravelers.Add("Activites:500");

            List<string> cleanTravelers = CleanseData.CleanData(dirtyTravelers);

            Assert.AreEqual(cleanTravelers[0], "BeeRad");
            Assert.AreEqual(cleanTravelers[1], "100");
            Assert.AreEqual(cleanTravelers[2], "200");
            Assert.AreEqual(cleanTravelers[3], "300");
            Assert.AreEqual(cleanTravelers[4], "400");

            Assert.AreEqual(cleanTravelers[5], "Rachel");
            Assert.AreEqual(cleanTravelers[6], "200");
            Assert.AreEqual(cleanTravelers[7], "300");
            Assert.AreEqual(cleanTravelers[8], "400");
            Assert.AreEqual(cleanTravelers[9], "500");
        }

        [Test]
        public void CleanseDataTest02()
        {
            List<string> dirtyTravelers = new List<string>();

            dirtyTravelers.Add("Name:BeeRad");
            dirtyTravelers.Add("FuelFlight:100.12");
            dirtyTravelers.Add("FoodDrink:200.45");
            dirtyTravelers.Add("Lodging:300.76");
            dirtyTravelers.Add("Activites:400.45");

            dirtyTravelers.Add("Name:Rachel");
            dirtyTravelers.Add("FuelFlight:200.76");
            dirtyTravelers.Add("FoodDrink:300.98");
            dirtyTravelers.Add("Lodging:400.23");
            dirtyTravelers.Add("Activites:500.45");

            dirtyTravelers.Add("Name:Shawn");
            dirtyTravelers.Add("FuelFlight:100.45");
            dirtyTravelers.Add("FoodDrink:200.76");
            dirtyTravelers.Add("Lodging:300.23");
            dirtyTravelers.Add("Activites:400.67");

            dirtyTravelers.Add("Name:Skye");
            dirtyTravelers.Add("FuelFlight:200.34");
            dirtyTravelers.Add("FoodDrink:300.67");
            dirtyTravelers.Add("Lodging:400.08");
            dirtyTravelers.Add("Activites:500.23");

            List<string> cleanTravelers = CleanseData.CleanData(dirtyTravelers);

            Assert.AreEqual(cleanTravelers[0], "BeeRad");
            Assert.AreEqual(cleanTravelers[1], "100.12");
            Assert.AreEqual(cleanTravelers[2], "200.45");
            Assert.AreEqual(cleanTravelers[3], "300.76");
            Assert.AreEqual(cleanTravelers[4], "400.45");

            Assert.AreEqual(cleanTravelers[5], "Rachel");
            Assert.AreEqual(cleanTravelers[6], "200.76");
            Assert.AreEqual(cleanTravelers[7], "300.98");
            Assert.AreEqual(cleanTravelers[8], "400.23");
            Assert.AreEqual(cleanTravelers[9], "500.45");

            Assert.AreEqual(cleanTravelers[10], "Shawn");
            Assert.AreEqual(cleanTravelers[11], "100.45");
            Assert.AreEqual(cleanTravelers[12], "200.76");
            Assert.AreEqual(cleanTravelers[13], "300.23");
            Assert.AreEqual(cleanTravelers[14], "400.67");

            Assert.AreEqual(cleanTravelers[15], "Skye");
            Assert.AreEqual(cleanTravelers[16], "200.34");
            Assert.AreEqual(cleanTravelers[17], "300.67");
            Assert.AreEqual(cleanTravelers[18], "400.08");
            Assert.AreEqual(cleanTravelers[19], "500.23");
        }
    }
}
