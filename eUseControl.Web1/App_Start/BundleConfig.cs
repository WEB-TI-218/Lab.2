using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace eUseControl.Web1.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles) 
        {
            //Bootstrap
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                "~/Content/vendor/css/bootstrap.min.css", new CssRewriteUrlTransform()));

            //Bootstrap 
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                "~/Scpripts/vendor/js/bootstrap.min.js"));

            
            //Font Awesome
            bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include(
                "~/Content/font-awesome.min.css", new CssRewriteUrlTransform()));

            //Slick
            bundles.Add(new StyleBundle("~/bundles/slick/css").Include(
                "~/Content/vendor/css/slick.css", new CssRewriteUrlTransform()));

            //Slick theme
            bundles.Add(new StyleBundle("~/bundles/slicktheme/css").Include(
                "~/Content/vendor/css/slick-theme.css", new CssRewriteUrlTransform()));

            //Nousleader
            bundles.Add(new StyleBundle("~/bundles/nouslider/css").Include(
               "~/Content/vendor/css/nouislider.min.css", new CssRewriteUrlTransform()));

            //MainStyle
            bundles.Add(new StyleBundle("~/bundles/mainstyle/css").Include(
               "~/Content/vendor/css/style.css", new CssRewriteUrlTransform()));

            //jquery 
            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                "~/Content/vendor/js/jquery.min.js"));
           
            //Slick
            bundles.Add(new ScriptBundle("~/bundles/slick/js").Include(
                "~/Content/vendor/js/slick.min.js"));

            //Nousleader
            bundles.Add(new ScriptBundle("~/bundles/nouislider/js").Include(
                "~/Content/vendor/js/nouislider.min.js"));

            //jquery.zoom
            bundles.Add(new ScriptBundle("~/bundles/jqueryzoom/js").Include(
                "~/Content/vendor/js/jquery.zoom.min.js"));

            //main
            bundles.Add(new ScriptBundle("~/bundles/mainscript/js").Include(
                "~/Content/vendor/js/main.js"));



        }

    }
    
}