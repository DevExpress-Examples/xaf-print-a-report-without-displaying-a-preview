using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using DevExpress.ExpressApp.ReportsV2;
using DevExpress.XtraReports.UI;
using System.IO;
using DevExpress.XtraPrinting;

namespace InstantPrintReportsV2Example.Web {
    public partial class InstantPrintReport : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string reportDataHandle = Request.QueryString["reportContainerHandle"];
            ReportsModuleV2 module = ReportsModuleV2.FindReportsModule(ApplicationReportObjectSpaceProvider.ContextApplication.Modules);
            if(!String.IsNullOrEmpty(reportDataHandle) && module != null) {
                XtraReport report = null;
                try {
                    report = ReportDataProvider.ReportsStorage.GetReportContainerByHandle(reportDataHandle).Report;
                    module.ReportsDataSourceHelper.SetupBeforePrint(report, null, null, false, null, false);
                    using(MemoryStream ms = new MemoryStream()) {
                        report.CreateDocument();
                        PdfExportOptions options = new PdfExportOptions();
                        options.ShowPrintDialogOnOpen = true;
                        report.ExportToPdf(ms, options);
                        ms.Seek(0, SeekOrigin.Begin);
                        byte[] reportContent = ms.ToArray();
                        Response.ContentType = "application/pdf";
                        Response.Clear();
                        Response.OutputStream.Write(reportContent, 0, reportContent.Length);
                        Response.End();
                    }
                }
                finally {
                    if (report != null) report.Dispose();
                }
            }
        }
    }
}
