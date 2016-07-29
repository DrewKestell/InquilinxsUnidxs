using System.Web.Optimization;

namespace InquilinxsUnidxs
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                  "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                 "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                 "~/Scripts/knockout-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/underscore").Include(
                "~/Scripts/underscore*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-to-dictionary").Include(
                "~/Scripts/jquery-to-dictionary.js"));

            bundles.Add(new ScriptBundle("~/bundles/global").Include(
                "~/Content/JS/Global.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/CSS/Bootstrap/bootstrap.css",
                "~/Content/CSS/site.css"));
        }
    }
}