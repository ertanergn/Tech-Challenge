using System.Web;
using System.Web.Optimization;

namespace BowlingScoreCalculator
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/JQuery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/Bootstrap/bootstrap.*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/Knockout/knockout-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                        "~/Scripts/site.js"));

            #endregion

            #region Styles

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                        "~/Content/css/bootstrap.*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/css/site.css"));

            #endregion
        }
    }
}