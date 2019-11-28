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
            Return String.Format("" & ControlChars.CrLf & _
"            if(!ASPx.Browser.Edge) {{" & ControlChars.CrLf & _
"                var iframe = document.getElementById('reportout');" & ControlChars.CrLf & _
"                if (iframe != null) {{" & ControlChars.CrLf & _
"                    document.body.removeChild(iframe);" & ControlChars.CrLf & _
"                }}" & ControlChars.CrLf & _
"                iframe = document.createElement('iframe');" & ControlChars.CrLf & _
"                iframe.setAttribute('id', 'reportout');" & ControlChars.CrLf & _
"                iframe.style.width = 0;" & ControlChars.CrLf & _
"                iframe.style.height = 0;" & ControlChars.CrLf & _
"                iframe.style.border = 0;" & ControlChars.CrLf & _
"                document.body.appendChild(iframe);" & ControlChars.CrLf & _
"                document.getElementById('reportout').contentWindow.location = '{0}';" & ControlChars.CrLf & _
"            }} else {{" & ControlChars.CrLf & _
"                window.open('{0}', '_blank');" & ControlChars.CrLf & _
"            }}" & ControlChars.CrLf & _
"            ", url)
        End Function
    End Class
End Namespace
