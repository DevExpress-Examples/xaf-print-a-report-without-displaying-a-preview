Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


Imports DevExpress.ExpressApp.ReportsV2
Imports DevExpress.XtraReports.UI
Imports System.IO
Imports DevExpress.XtraPrinting

Namespace InstantPrintReportsV2Example.Web
    Partial Public Class InstantPrintReport
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim reportDataHandle As String = Request.QueryString("reportContainerHandle")
            Dim [module] As ReportsModuleV2 = ReportsModuleV2.FindReportsModule(ApplicationReportObjectSpaceProvider.ContextApplication.Modules)
            If (Not String.IsNullOrEmpty(reportDataHandle)) AndAlso [module] IsNot Nothing Then
                Dim report As XtraReport = Nothing
                Try
                    report = ReportDataProvider.ReportsStorage.GetReportContainerByHandle(reportDataHandle).Report
                    [module].ReportsDataSourceHelper.SetupBeforePrint(report, Nothing, Nothing, False, Nothing, False)
                    Using ms As New MemoryStream()
                        report.CreateDocument()
                        Dim options As New PdfExportOptions()
                        options.ShowPrintDialogOnOpen = True
                        report.ExportToPdf(ms, options)
                        ms.Seek(0, SeekOrigin.Begin)
                        Dim reportContent() As Byte = ms.ToArray()
                        Response.ContentType = "application/pdf"
						Response.AddHeader("Content-Disposition", "attachement; filename=MyFileName.pdf")
                        Response.Clear()
                        Response.OutputStream.Write(reportContent, 0, reportContent.Length)
                        Response.End()
                    End Using
                Finally
                    If report IsNot Nothing Then
                        report.Dispose()
                    End If
                End Try
            End If
        End Sub
    End Class
End Namespace