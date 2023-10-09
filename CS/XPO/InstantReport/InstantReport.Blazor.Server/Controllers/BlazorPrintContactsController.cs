using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraReports.UI;
using InstantPrintReportsV2Example.Module.Controllers;
using Microsoft.JSInterop;

namespace InstantReport.Blazor.Server.Controllers {
    public class BlazorPrintContactsController : PrintContactsController {
        readonly IReportExportService reportExportService;
        readonly IJSRuntime jsRuntime;
        public BlazorPrintContactsController() : base() { }

        [ActivatorUtilitiesConstructor]
        public BlazorPrintContactsController(IServiceProvider serviceProvider) : base() {
            reportExportService = serviceProvider.GetService<IReportExportService>();
            jsRuntime = serviceProvider.GetService<IJSRuntime>();
        }

        protected override async void PrintReport(string reportDisplayName, System.Collections.IList selectedObjects) {
            using XtraReport report = reportExportService.LoadReport<ReportDataV2>(r => r.DisplayName == reportDisplayName);
            // Filter and sort report data
            CriteriaOperator objectsCriteria = ((BaseObjectSpace)ObjectSpace).GetObjectsCriteria(((ObjectView)View).ObjectTypeInfo, selectedObjects);
            SortProperty[] sortProperties = { new SortProperty("Age", SortingDirection.Descending) };
            reportExportService.SetupReport(report, objectsCriteria.ToString(), sortProperties);

            using Stream s = reportExportService.ExportReport(report, DevExpress.XtraPrinting.ExportTarget.Pdf);
            using var streamRef = new DotNetStreamReference(s);
            var fileName = reportDisplayName + ".pdf";
            await jsRuntime.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
        }
    }
}
