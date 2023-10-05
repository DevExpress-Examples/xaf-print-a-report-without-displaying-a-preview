using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Xpo;
using DevExpress.XtraReports.UI;
using InstantPrintReportsV2Example.Module.Controllers;
using Microsoft.Extensions.DependencyInjection;
using DevExpress.Xpo.DB;

namespace InstantPrintReportsV2Example.Module.Win {
    public class WinInstantPrintReportController : PrintContactsController {
        public WinInstantPrintReportController() : base() { }

        [ActivatorUtilitiesConstructor]
        public WinInstantPrintReportController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        protected override void PrintReport(IReportDataV2 reportData, System.Collections.IList selectedObjects) {
            using var report = LoadReport(reportData);
            ReportsModuleV2 reportsModule = ReportsModuleV2.FindReportsModule(Application.Modules);
            if (reportsModule != null && reportsModule.ReportsDataSourceHelper != null) {
                // Apply filtering and sorting to the report data.
                CriteriaOperator objectsCriteria = ((BaseObjectSpace)ObjectSpace).GetObjectsCriteria(((ObjectView)View).ObjectTypeInfo, selectedObjects);
                SortProperty[] sortProperties = { new SortProperty("Age", SortingDirection.Descending) };
                reportsModule.ReportsDataSourceHelper.SetupBeforePrint(report, null, objectsCriteria, true, sortProperties, true);

                report.PrintDialog();
            }
        }
    }
}
