using DevExpress.ExpressApp.ReportsV2;
using DevExpress.XtraReports.UI;
using InstantPrintReportsV2Example.Module.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace InstantPrintReportsV2Example.Module.Win {
    public class WinInstantPrintReportController : PrintContactsController {
        public WinInstantPrintReportController() : base() { }

        [ActivatorUtilitiesConstructor]
        public WinInstantPrintReportController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        protected override void PrintReport(IReportDataV2 reportData) {
            using var report = LoadReport(reportData);
            report.PrintDialog();
        }
    }
}
