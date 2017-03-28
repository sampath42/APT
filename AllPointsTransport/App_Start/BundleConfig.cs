using System.Web;
using System.Web.Optimization;

namespace AllPointsTransport
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/js/bootstrap.js",
                      "~/Scripts/js/base.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                        "~/Scripts/Common.js"));

            bundles.Add(new StyleBundle("~/Content/Styles").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/bootstrap-responsive.min.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/css/style.css",
                      "~/Content/css/pages/dashboard.css",
                      "~/Content/apt-font.css",                     
                      "~/Content/apt.css"));
        }
    }
}
