using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraReports.UI;
using InstantPrintReportsV2Example.Module.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace InstantPrintReportsV2Example.Module.Win {
    public class WinInstantPrintReportController : PrintContactsController {
        readonly IReportExportService reportExportService;
        public WinInstantPrintReportController() : base() { }

        [ActivatorUtilitiesConstructor]
        public WinInstantPrintReportController(IServiceProvider serviceProvider) : base() { 
            reportExportService = serviceProvider.GetService<IReportExportService>();
        }

        protected override void PrintReport(string reportDisplayName, System.Collections.IList selectedObjects) {
            using XtraReport report = reportExportService.LoadReport<ReportDataV2>(r => r.DisplayName == reportDisplayName);
            // Filter and sort report data.
            CriteriaOperator objectsCriteria = ((BaseObjectSpace)ObjectSpace).GetObjectsCriteria(((ObjectView)View).ObjectTypeInfo, selectedObjects);
            SortProperty[] sortProperties = { new SortProperty("Age", SortingDirection.Descending) };
            reportExportService.SetupReport(report, objectsCriteria.ToString(), sortProperties);
            report.PrintDialog();
        }
    }
}
