using System.Web.Optimization;
using BundleTransformer.Core;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Transformers;

namespace Project
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-upload.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/classie.js",
                      "~/Scripts/snap.svg-min.js",
                      "~/Scripts/inputEffect.js"));

            bundles.Add(new ScriptBundle("~/bundles/markdown").Include(
                      "~/Scripts/bootstrap-markdown.js",
                      "~/Content/bootstrap-markdown/locale/bootstrap-markdown.ru.js"));

            bundles.Add(new ScriptBundle("~/bundles/menu").Include(
                      "~/Scripts/menu.js"));
            bundles.Add(new ScriptBundle("~/bundles/owl").Include(
                    "~/Scripts/owl.carousel.js"));
            bundles.Add(new ScriptBundle("~/bundles/tabs").Include(
                    "~/Scripts/Tabs.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/global.css",
                      "~/Content/inputs.css",
                      "~/Content/menu.css",
                      "~/Content/news.css"));

            bundles.Add(new StyleBundle("~/Content/owl").Include(
                      "~/Content/carousel/owl.carousel.css",
                      "~/Content/carousel/owl.theme.css",
                      "~/Content/carousel/owl.transitions.css"));

            bundles.Add(new StyleBundle("~/Content/tabs").Include(
                     "~/Content/Tabs/tabs.css",
                     "~/Content/Tabs/tabstyles.css"));

            bundles.Add(new StyleBundle("~/Content/inputs").Include(
                "~/Content/InputEffect/component.css"));

            bundles.Add(new StyleBundle("~/Content/markdown").Include(
                    "~/Content/bootstrap-markdown/bootstrap-markdown.min.css"));
        }
    }
}
