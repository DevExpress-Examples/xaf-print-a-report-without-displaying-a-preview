Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Web
Imports InstantPrintReportsV2Example.Module.Controllers
Imports DevExpress.ExpressApp.ReportsV2
Imports DevExpress.ExpressApp.Web

Namespace InstantPrintReportsV2Example.Module.Web
    Public Class WebInstantPrintReportController
        Inherits PrintContactsController

        Protected Overrides Sub PrintReport(ByVal reportData As IReportDataV2)
            Dim reportContainerHandle As String = ReportDataProvider.ReportsStorage.GetReportContainerHandle(reportData)
            CType(WebApplication.Instance.MainWindow, WebWindow).RegisterStartupScript("InstantPrintReport", GetPrintingScript(reportContainerHandle), overwrite:= True)
        End Sub
        Private Function GetPrintingScript(ByVal reportContainerHandle As String) As String
            Dim url As String = HttpContext.Current.Response.ApplyAppPathModifier( _
                String.Format("~/InstantPrintReport.aspx?reportContainerHandle={0}", reportContainerHandle))
                Return String.Format("
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
        ", url)
        End Function
    End Class
End Namespace
