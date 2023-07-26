using DevExpress.ExpressApp.ReportsV2;
using DevExpress.XtraPrinting;
using InstantPrintReportsV2Example.Module.Controllers;

namespace InstantReport.Blazor.Server.Controllers {
    public class BlazorPrintContactsController : PrintContactsController {
        public BlazorPrintContactsController() : base() { }

        [ActivatorUtilitiesConstructor]
        public BlazorPrintContactsController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        protected override void PrintReport(IReportDataV2 reportData) {
            using var report = LoadReport(reportData);
            report.CreateDocument();
            PrintToolBase tool = new PrintToolBase(report.PrintingSystem);
            tool.Print();
        }
    }
}
