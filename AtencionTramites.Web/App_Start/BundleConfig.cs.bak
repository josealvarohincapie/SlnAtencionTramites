using System.Web;
using System.Web.Optimization;
using System.Reflection;

namespace AtencionTramites
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Ultimus.Framework.ResourceTrasform().GetBundleScriptsResources());

            bundles.Add(new ScriptBundle("~/bundles/tether").Include("~/Scripts/tether/tether.min.js"));
            bundles.Add(new StyleBundle("~/Content/tether").Include("~/Content/tether/tether.css"));

            bundles.Add(new ScriptBundle("~/bundles/tether").Include("~/Scripts/tether/tether.min.js"));
            bundles.Add(new StyleBundle("~/Content/tether").Include("~/Content/tether/tether.css"));

            bundles.Add(new ScriptBundle("~/bundles/tether").Include("~/Scripts/tether/tether.min.js"));
            bundles.Add(new StyleBundle("~/Content/tether").Include("~/Content/tether/tether.css"));

            bundles.Add(new ScriptBundle("~/bundles/tether").Include("~/Scripts/tether/tether.min.js"));
            bundles.Add(new StyleBundle("~/Content/tether").Include("~/Content/tether/tether.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/placeholder").Include(
           "~/Scripts/jquery.html5-placeholder-shim.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-migrate").Include(
                        "~/Scripts/jquery-migrate-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/maskedinput").Include("~/Scripts/jquery.maskedinput-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/FastClick").Include("~/Scripts/fastclick.js"));

            bundles.Add(new ScriptBundle("~/bundles/moneymask").Include("~/Scripts/jquery.moneymask.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-dataTables").Include("~/Scripts/DataTables/jquery.dataTables.js"));
            bundles.Add(new ScriptBundle("~/bundles/toastr").Include("~/Scripts/toastr.js"));
            bundles.Add(new ScriptBundle("~/bundles/moment").Include("~/Scripts/moment.js")
                                                            .Include("~/Scripts/moment-precise-range.js"));
            bundles.Add(new ScriptBundle("~/bundles/bonsai").Include("~/Scripts/jquery.qubit.js").Include("~/Scripts/jquery.bonsai.js"));

            bundles.Add(new ScriptBundle("~/bundles/autoNumeric").Include("~/Scripts/autoNumeric/autoNumeric-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/dashboard").Include("~/Content/dashboard.css"));
            bundles.Add(new StyleBundle("~/Content/awesome").Include("~/Content/font-awesome.css"));
            bundles.Add(new StyleBundle("~/Content/toastr").Include("~/Content/toastr.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap-datepicker").Include("~/Content/bootstrap-datepicker.css"));
            bundles.Add(new StyleBundle("~/Content/jquery-dataTables").Include("~/Content/DataTables/css/jquery.dataTables.css"));
            bundles.Add(new StyleBundle("~/Content/bonsai").Include("~/Content/jquery.bonsai.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new ScriptBundle("~/bundles/InputMask")
                .Include("~/Scripts/jquery.inputmask/inputmask.min.js")
                .Include("~/Scripts/jquery.inputmask/jquery.inputmask.min.js")
                .Include("~/Scripts/jquery.inputmask/inputmask.extensions.min.js")
                .Include("~/Scripts/jquery.inputmask/inputmask.numeric.extensions.min.js")
                .Include("~/Scripts/jquery.inputmask/inputmask.phone.extensions.min.js")
                .Include("~/Scripts/jquery.inputmask/inputmask.regex.extensions.min.js")
                .Include("~/Scripts/jquery.inputmask/inputmask.date.extensions.min.js")
                );

            bundles.Add(new ScriptBundle("~/Scripts/AtencionTramitesAse/Radicado")
                .Include("~/Ultimus.Framework/AtencionTramitesAse/API.Radicado.js")
                .Include("~/Ultimus.Framework/Ultimus.API.FuncionesGlobales.js")
                );

            bundles.Add(new ScriptBundle("~/Scripts/AtencionTramitesAse/Seguimiento")
                .Include("~/Ultimus.Framework/AtencionTramitesAse/API.Seguimiento.js")
                .Include("~/Ultimus.Framework/Ultimus.API.FuncionesGlobales.js")
                );

            bundles.Add(new ScriptBundle("~/Scripts/ClasificacionTramites/ClasificacionTramite")
                .Include("~/Ultimus.Framework/ClasificacionTramites/API.ClasificacionTramite.js")
                .Include("~/Ultimus.Framework/Ultimus.API.FuncionesGlobales.js")
                );

            bundles.Add(new ScriptBundle("~/Scripts/ClasificacionTramites/Seguimiento")
                .Include("~/Ultimus.Framework/ClasificacionTramites/API.Seguimiento.js")
                .Include("~/Ultimus.Framework/Ultimus.API.FuncionesGlobales.js")
                );

            bundles.Add(new ScriptBundle("~/Scripts/AtencionTramitesAse/GenerarDocumento")
                .Include("~/Ultimus.Framework/AtencionTramitesAse/API.GenerarDocumento.js")
                .Include("~/Ultimus.Framework/Ultimus.API.FuncionesGlobales.js")
                );
        }
    }
}