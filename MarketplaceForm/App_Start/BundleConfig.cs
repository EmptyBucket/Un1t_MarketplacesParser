using System.Web.Optimization;

namespace MarketplaceForm
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/bower_components/jquery/dist/jquery.js",
                "~/bower_components/jquery-file-upload/js/vendor/jquery.ui.widget.js",
                "~/bower_components/jquery-file-upload/js/jquery.fileupload.js",
                "~/bower_components/jquery-file-upload/js/jquery.iframe-transport.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/bower_components/bootstrap/dist/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datepicker").Include(
                "~/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.js",
                "~/bower_components/bootstrap-datepicker/dist/locales/bootstrap-datepicker.ru.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/bower_components/bootstrap/dist/css/bootstrap.css",
                "~/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.css",
                "~/Content/site.css"));
        }
    }
}