using System.Collections.Generic;
using System.IO;
using System.Web.Optimization;

namespace teste_desenvolvimento.App_Start
{
    public class AsIsBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }

        public virtual IEnumerable<FileInfo> OrderFiles(BundleContext context, IEnumerable<FileInfo> files)
        {
            return files;
        }
    }

    public static class BundlesConfig
    {
        public static void Register(BundleCollection bundles)
        {
            var estilos = new StyleBundle("~/css/estilos");

            BundleTable.EnableOptimizations = false;

            estilos.Orderer = new AsIsBundleOrderer();

            bundles.Add(
                estilos.Include(
                    "~/Content/bootstrap.css",
                    "~/Content/bootstrap-theme.css",
                    "~/Content/Site.css",
                    "~/css/font-awesome.css",
                    "~/css/prettify.min.css",
                    "~/Content/bootstrap-duallistbox.css",
                    "~/Content/datatables.css",
                    "~/Content/AutoFill-2.1.1/css/autoFill.bootstrap.css",
                    "~/Content/Buttons-1.1.2/css/buttons.bootstrap.css",
                    "~/Content/Chartist/chartist.css",
                    "~/Content/ColReorder-1.3.1/css/colReorder.bootstrap.css",
                    "~/Content/FixedColumns-3.2.1/css/fixedColumns.bootstrap.css",
                    "~/Content/FixedHeader-3.1.1/css/fixedHeader.bootstrap.css",
                    "~/Content/KeyTable-2.1.1/css/keyTable.bootstrap.css",
                    "~/Content/Responsive-2.0.2/css/responsive.bootstrap.css",
                    "~/Content/RowReorder-1.1.1/css/rowReorder.bootstrap.css",
                    "~/Content/Scroller-1.4.1/css/scroller.bootstrap.css",
                    "~/Content/Select-1.1.2/css/select.bootstrap.css",
                    "~/Content/custom.css",
                    "~/Content/bootstrap-datetimepicker.css",
                    "~/Scripts/select2/select2.css",
                    "~/Scripts/select2/select2-bootstrap.css"
                ));

            var scripts = new ScriptBundle("~/javascript");

            scripts.Orderer = new AsIsBundleOrderer();

            bundles.Add(
                scripts
                    .Include("~/Scripts/modernizr-{version}.js",
                             "~/Scripts/moment-with-locales.js",
                             "~/Scripts/jquery-{version}.js",
                             "~/Scripts/bootstrap.js",
                             "~/Scripts/jquery.metisMenu.js",
                             "~/Scripts/custom.js",
                             "~/Scripts/bootstrap-datetimepicker.js",
                             "~/Scripts/jquery.validate.js",
                             "~/Scripts/jquery.validate.unobtrusive.js",
                             "~/Scripts/jquery.unobtrusive-ajax.js",
                             "~/Scripts/additional-methods.js",
                              "~/Scripts/jvalidator-methods-number.js",
                             "~/Scripts/jquery.validate.bootstrap-config.js",
                             "~/Scripts/methods_pt.js",
                             "~/Scripts/messages_pt_BR.js",
                             "~/Scripts/seed.jquery.validation.js",
                             "~/Scripts/datatables.js",
                             "~/Scripts/AutoFill-2.1.1/js/dataTables.autoFill.js",
                             "~/Scripts/AutoFill-2.1.1/js/autoFill.bootstrap.js",
                             "~/Scripts/Buttons-1.1.2/js/dataTables.buttons.js",
                             "~/Scripts/Buttons-1.1.2/js/buttons.print.js",
                             "~/Scripts/Buttons-1.1.2/js/buttons.html5.js",
                             "~/Scripts/Buttons-1.1.2/js/buttons.flash.js",
                             "~/Scripts/Buttons-1.1.2/js/buttons.colVis.js",
                             "~/Scripts/Buttons-1.1.2/js/buttons.bootstrap.js",
                             "~/Scripts/ColReorder-1.3.1/js/dataTables.colReorder.js",
                             "~/Scripts/DataTables-1.10.11/js/jquery.dataTables.js",
                             "~/Scripts/DataTables-1.10.11/js/dataTables.bootstrap.js",
                             "~/Scripts/FixedColumns-3.2.1/js/dataTables.fixedColumns.js",
                             "~/Scripts/FixedHeader-3.1.1/js/dataTables.fixedHeader.js",
                             "~/Scripts/KeyTable-2.1.1/js/dataTables.keyTable.js",
                             "~/Scripts/Responsive-2.0.2/js/dataTables.responsive.js",
                             "~/Scripts/Responsive-2.0.2/js/responsive.bootstrap.js",
                             "~/Scripts/RowReorder-1.1.1/js/dataTables.rowReorder.js",
                             "~/Scripts/Scroller-1.4.1/js/dataTables.scroller.js",
                             "~/Scripts/Select-1.1.2/js/dataTables.select.js",
                             "~/Scripts/jquery.cascadingdropdown.js",
                             "~/Scripts/jquery.bootstrap-duallistbox.js",
                             "~/Scripts/jquery.tabledit.js",
                             "~/Scripts/FileSaver.js",
                             "~/Scripts/select2/select2.full.js",
                             "~/Scripts/select2/i18n/pt-BR.js",
                              "~/Scripts/moment-with-locales.js",
                             "~/Scripts/moment.js",
                             "~/Scripts/moment-pt-br.js",
                             "~/Scripts/jquery.maskedinput.js",
                              "~/Scripts/jquery.maskmoney.js",
                             "~/Scripts/printThis/printThis.js",
                             "~/Scripts/temporizacao-mensagem-sucesso.js",
                             "~/Scripts/Chart.js"

                    ));
        }
    }
}