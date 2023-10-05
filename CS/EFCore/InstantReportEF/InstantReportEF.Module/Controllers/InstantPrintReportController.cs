using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.XtraReports.UI;
using Microsoft.Extensions.DependencyInjection;
using MySolution.Module.BusinessObjects;

namespace InstantPrintReportsV2Example.Module.Controllers {
    public abstract class PrintContactsController : ObjectViewController<ListView, Contact> {
        readonly IReportExportService reportExportService;

        [ActivatorUtilitiesConstructor]
        public PrintContactsController(IServiceProvider serviceProvider) : this() {
            reportExportService = serviceProvider.GetRequiredService<IReportExportService>();
        }
        public PrintContactsController() {
            SimpleAction printAction = new SimpleAction(this, "PrintContacts", PredefinedCategory.Reports);
            printAction.ImageName = "Action_Printing_Print";
            printAction.Execute += delegate (object sender, SimpleActionExecuteEventArgs e) {
                using var objectSpace = Application.CreateObjectSpace(typeof(ReportDataV2));
                IReportDataV2 reportData = objectSpace.FindObject<ReportDataV2>(
                    new BinaryOperator("DisplayName", "ContactReport"));
                if (reportData == null) {
                    throw new UserFriendlyException("Cannot find the 'Contacts Report' report.");
                } else {
                    PrintReport(reportData, e.SelectedObjects);
                }
            };
        }
        protected XtraReport LoadReport(IReportDataV2 reportData) {
            XtraReport report = reportExportService.LoadReport(reportData);
            reportExportService.SetupReport(report);
            return report;
        }
        protected abstract void PrintReport(IReportDataV2 reportData, System.Collections.IList selectedObjects);
    }
}
