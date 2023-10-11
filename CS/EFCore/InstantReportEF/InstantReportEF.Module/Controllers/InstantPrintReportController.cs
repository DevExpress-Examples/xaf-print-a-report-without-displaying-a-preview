using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using MySolution.Module.BusinessObjects;

namespace InstantPrintReportsV2Example.Module.Controllers {
    public abstract class PrintContactsController : ObjectViewController<ListView, Contact> {
        public PrintContactsController() {
            SimpleAction printAction = new SimpleAction(this, "PrintContacts", PredefinedCategory.Reports);
            printAction.ImageName = "Action_Printing_Print";
            printAction.Execute += delegate (object sender, SimpleActionExecuteEventArgs e) {
                PrintReport("ContactReport", e.SelectedObjects);
            };
         }
        protected abstract void PrintReport(string reportDisplayName, System.Collections.IList selectedObjects);
    }
}
