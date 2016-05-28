using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BWQ.TripCalculator.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Scripts").Include(
                "~/scripts/jquery*",
                "~/scripts/ai*",
                "~/scripts/bootstrap*"
                ));

            bundles.Add(new StyleBundle("~/bundles/Styles").Include(
                "~/Content/bootstrap*",
                "~/Content/MasterPage.css",
                "~/Content/Body.css"
                ));

            BundleTable.EnableOptimizations = true;
        }
    }
}