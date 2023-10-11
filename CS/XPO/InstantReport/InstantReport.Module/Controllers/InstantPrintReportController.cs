using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;
using dxTestSolution.Module.BusinessObjects;
using Microsoft.Extensions.DependencyInjection;
using DevExpress.XtraReports.UI;

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
