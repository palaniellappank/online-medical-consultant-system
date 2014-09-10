using System.Web;
using System.Web.Optimization;

namespace OMCS.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jsOMCS").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/underscore.js",
                        "~/Scripts/backbone.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/bootbox.js",
                        "~/Content/mCustomScrollbar/jquery.mCustomScrollbar.js",
                        "~/Content/select2/select2.js",
                        "~/Scripts/jquery.metisMenu.js",
                        "~/Scripts/site.js"));

            bundles.Add(new ScriptBundle("~/bundles/jsTemplateEditor").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/underscore.js",
                        "~/Scripts/backbone.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/jquery.blockUI.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/jquery.metisMenu.js",
                        "~/Scripts/site.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/bundles/cssOMCS").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/font-awesome.css",
                        "~/Content/mCustomScrollbar/jquery.mCustomScrollbar.css",
                        "~/Content/select2/select2.css",
                        "~/Content/toggle-switch.css",
                        "~/Content/themes/base/jquery-ui.css",
                        "~/Content/Site.css"));
        }
    }
}