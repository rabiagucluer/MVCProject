using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace HBTiyatro.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/scripts/jquery-3.3.1.js",
                        "~/scripts/bootstrap.min.js",
                        "~/scripts/jquery-3.3.1.min.js",
                        "~/scripts/jquery-3.3.1.slim.js",
                        "~/scripts/jquery-3.3.1.slim.min.js",
                        "~/scripts/bootstrap.js",
                        "~/scripts/jquery-3.3.1.intellisense.js",
                        "~/scripts/jquery.validate-vsdoc.js",
                        "~/scripts/jquery.validate.js",
                        "~/scripts/jquery.validate.min.js",
                        "~/scripts/jquery.validate.unobtrusive.js",
                        "~/scripts/jquery.validate.unobtrusive.min.js",
                        "~/scripts/npm.js",
                        "~/scripts/slider.js"
                        ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                        "~/Content/bkootstrap.min.css",
                        "~/CSS/StyleS1.css",
                        "~/Content/bootstrap-theme.min.css",
                        "~/Content/bootstrap-theme.css",
                        "~/Content/bootstrap.css",
                        "~/CSS/AntakyaStyle.css",
                        "~/CSS/HakkimizdaStyle.css",
                        "~/CSS/IletisimStyle.css",
                        "~/CSS/OyuncularStyle.css"
                        ));


        }


    }
}