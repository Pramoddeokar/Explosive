using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ngEdu.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/Vendors/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                "~/assets/plugins/jquery/jquery-2.1.3.min.js",
                "~/Scripts/Vendors/bootstrap.js",
                "~/Scripts/Vendors/toastr.js",
                "~/Scripts/Vendors/jquery.raty.js",
                "~/Scripts/Vendors/respond.src.js",
                "~/Scripts/Vendors/angular.js",
                "~/Scripts/Vendors/angular-route.js",
                "~/Scripts/Vendors/angular-cookies.js",
                "~/Scripts/Vendors/angular-validator.js",
                "~/Scripts/Vendors/angular-base64.js",
                "~/Scripts/Vendors/angular-file-upload.js",
                "~/Scripts/Vendors/angucomplete-alt.min.js",
                "~/Scripts/Vendors/ui-bootstrap-tpls-0.13.1.js",
                "~/Scripts/Vendors/underscore.js",
                "~/Scripts/Vendors/raphael.js",
                "~/Scripts/Vendors/morris.js",
                "~/Scripts/Vendors/jquery.fancybox.js",
                "~/Scripts/Vendors/jquery.fancybox-media.js",
                "~/Scripts/Vendors/loading-bar.js",
                "~/assets/plugins/jquery-ui/jquery-ui.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                "~/Scripts/spa/modules/common.core.js",
                "~/Scripts/spa/modules/common.ui.js",
                "~/Scripts/spa/app.js",
                "~/Scripts/spa/services/apiService.js",
                "~/Scripts/spa/services/notificationService.js",
                "~/Scripts/spa/services/membershipService.js",
                "~/Scripts/spa/services/fileUploadService.js",
                "~/Scripts/spa/layout/topBar.directive.js",
                "~/Scripts/spa/layout/sideBar.directive.js",
                "~/Scripts/spa/layout/customPager.directive.js",
                "~/Scripts/spa/directives/rating.directive.js",
                "~/Scripts/spa/directives/availableMovie.directive.js",
                "~/Scripts/spa/account/loginCtrl.js",
                "~/Scripts/spa/account/registerCtrl.js",
                "~/Scripts/spa/home/rootCtrl.js",
                "~/Scripts/spa/home/indexCtrl.js",
                "~/Scripts/spa/customers/customersCtrl.js",
                "~/Scripts/spa/customers/customersRegCtrl.js",
                "~/Scripts/spa/customers/customerEditCtrl.js",
                "~/Scripts/spa/movies/moviesCtrl.js",
                "~/Scripts/spa/movies/movieAddCtrl.js",
                "~/Scripts/spa/movies/movieDetailsCtrl.js",
                "~/Scripts/spa/movies/movieEditCtrl.js",
                "~/Scripts/spa/controllers/rentalCtrl.js",
                "~/Scripts/spa/rental/rentMovieCtrl.js",
                "~/Scripts/spa/rental/rentStatsCtrl.js",
                "~/assets/plugins/waves/waves.min.js"
                ));

             bundles.Add(new ScriptBundle("~/bundles/theme").Include(
                "~/assets/plugins/waves/waves.min.js",
                "~/assets/js/modern.js",
                "~/assets/js/pages/dashboard.js",
                "~/assets/js/pages/dashboard.js",
                "~/assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/assets/plugins/offcanvasmenueffects/js/classie.js",
                "~/assets/plugins/offcanvasmenueffects/js/main.js",
                "~/assets/plugins/offcanvasmenueffects/js/snap.svg-min.js"
               
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/content/css/site.css",
                "~/content/css/bootstrap.css",
                
                 "~/content/css/font-awesome.css",
                "~/content/css/morris.css",
                "~/content/css/toastr.css",
                "~/content/css/jquery.fancybox.css",
                "~/content/css/loading-bar.css"));

            bundles.Add(new StyleBundle("~/Content/theme").Include(
               "~/assets/plugins/waves/waves.min.css",
               "~/assets/css/modern.css",
                "~/assets/css/themes/white.css",
               "~/assets/css/custom.css",
               "~/assets/plugins/offcanvasmenueffects/css/menu_cornerbox.css"
              ));

            BundleTable.EnableOptimizations = false;
        }
    }
}