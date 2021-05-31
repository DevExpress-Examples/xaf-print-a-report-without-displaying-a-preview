using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using InstantPrintReportsV2Example.Module.Controllers;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.Web;

namespace InstantPrintReportsV2Example.Module.Web {
    public class WebInstantPrintReportController : PrintContactsController {
        protected override void PrintReport(IReportDataV2 reportData) {
            string reportContainerHandle = ReportDataProvider.ReportsStorage.GetReportContainerHandle(reportData);
            ((WebWindow)WebApplication.Instance.MainWindow).RegisterStartupScript(
                "InstantPrintReport", GetPrintingScript(reportContainerHandle), overwrite: true);
        }
        private string GetPrintingScript(string reportContainerHandle) {
            var url = HttpContext.Current.Response.ApplyAppPathModifier(
                string.Format("~/InstantPrintReport.aspx?reportContainerHandle={0}", reportContainerHandle));
            return string.Format(@"
            if(!ASPx.Browser.Edge) {{
                var iframe = document.getElementById('reportout');
                if (iframe != null) {{
                    document.body.removeChild(iframe);
                }}
                iframe = document.createElement('iframe');
                iframe.setAttribute('id', 'reportout');
                iframe.style.width = 0;
                iframe.style.height = 0;
                iframe.style.border = 0;
                document.body.appendChild(iframe);
                iframe.addEventListener('load', function(e) {{
                    if(iframe.contentDocument.contentType !== 'text/html') {{
                        iframe.contentWindow.print();
                    }}
                }});
                document.getElementById('reportout').contentWindow.location = '{0}';
            }} else {{
                window.open('{0}', '_blank');
            }}
            ", url);
        }
    }
}
