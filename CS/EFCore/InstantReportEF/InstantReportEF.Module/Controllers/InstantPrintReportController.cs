using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using MySolution.Module.BusinessObjects;

namespace InstantPrintReportsV2Example.Module.Controllers {
    public abstract class PrintContactsController : ObjectViewController<ListView, Contact> {
        public PrintContactsController() {
            SimpleAction printAction = new SimpleAction(this, "PrintContacts", PredefinedCategory.Reports);
            printAction.ImageName = "Action_Printing_Print";
            printAction.Execute += delegate (object sender, SimpleActionExecuteEventArgs e) {
                var reportOSProvider = ReportDataProvider.GetReportObjectSpaceProvider(Application.ServiceProvider);
                IObjectSpace objectSpace = reportOSProvider.CreateObjectSpace(typeof(ReportDataV2));
                IReportDataV2 reportData = objectSpace.FindObject<ReportDataV2>(
                    new BinaryOperator("DisplayName", "ContactReport"));
                if (reportData == null) {
                    throw new UserFriendlyException("Cannot find the 'Contacts Report' report.");
                } else {
                    PrintReport(reportData);
                }
            };
        }
        protected abstract void PrintReport(IReportDataV2 reportData);
    }
}
