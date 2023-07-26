using DevExpress.ExpressApp.ReportsV2;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using InstantPrintReportsV2Example.Module.Controllers;
using static System.Net.Mime.MediaTypeNames;

namespace InstantReport.Blazor.Server.Controllers {
    public class BlazorPrintContactsController : PrintContactsController {
        protected override void PrintReport(IReportDataV2 reportData) {
            ReportsModuleV2 reportsModule = ReportsModuleV2.FindReportsModule(Application.Modules);
            if (reportsModule != null && reportsModule.ReportsDataSourceHelper != null) {
                var reportStorage = ReportDataProvider.GetReportStorage(Application.ServiceProvider);
                XtraReport report = reportStorage.LoadReport(reportData);
                reportsModule.ReportsDataSourceHelper.SetupBeforePrint(report);
                report.CreateDocument();
                PrintToolBase tool = new PrintToolBase(report.PrintingSystem);
                tool.Print();
            }
        }
    }
}
