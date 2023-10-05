using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using InstantPrintReportsV2Example.Module.Controllers;
using Microsoft.JSInterop;

namespace InstantReport.Blazor.Server.Controllers {
    public class BlazorPrintContactsController : PrintContactsController {
        public BlazorPrintContactsController() : base() { }

        [ActivatorUtilitiesConstructor]
        public BlazorPrintContactsController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        protected override async void PrintReport(IReportDataV2 reportData, System.Collections.IList selectedObjects) {
            IJSRuntime jsRuntime = Application.ServiceProvider.GetRequiredService<IJSRuntime>();
            using var report = LoadReport(reportData);
            ReportsModuleV2 reportsModule = ReportsModuleV2.FindReportsModule(Application.Modules);
            if (reportsModule != null && reportsModule.ReportsDataSourceHelper != null) {
                // Apply filtering and sorting to the report data.
                CriteriaOperator objectsCriteria = ((BaseObjectSpace)ObjectSpace).GetObjectsCriteria(((ObjectView)View).ObjectTypeInfo, selectedObjects);
                SortProperty[] sortProperties = { new SortProperty("Age", SortingDirection.Descending) };
                reportsModule.ReportsDataSourceHelper.SetupBeforePrint(report, null, objectsCriteria, true, sortProperties, true);

                using MemoryStream ms = new MemoryStream();
                await report.ExportToPdfAsync(ms);
                ms.Position = 0;
                using var streamRef = new DotNetStreamReference(ms);
                var fileName = reportData.DisplayName + ".pdf";
                await jsRuntime.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
            }
        }
    }
}
