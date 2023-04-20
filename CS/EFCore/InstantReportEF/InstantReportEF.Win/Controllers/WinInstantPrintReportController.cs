using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstantPrintReportsV2Example.Module.Controllers;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.XtraReports.UI;

namespace InstantPrintReportsV2Example.Module.Win {
    public class WinInstantPrintReportController : PrintContactsController {
        protected override void PrintReport(IReportDataV2 reportData) {
            var reportStorage = ReportDataProvider.GetReportStorage(Application.ServiceProvider);
            XtraReport report = reportStorage.LoadReport(reportData);
            ReportsModuleV2 reportsModule = ReportsModuleV2.FindReportsModule(Application.Modules);
            if (reportsModule != null && reportsModule.ReportsDataSourceHelper != null) {
                reportsModule.ReportsDataSourceHelper.SetupBeforePrint(report);
                report.PrintDialog();
            }
        }
    }
}
