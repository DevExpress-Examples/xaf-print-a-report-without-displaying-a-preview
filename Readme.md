<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128592402/23.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E5146)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# XAF - How to Print a report without displaying a preview

This example demonstrates how to implement an Action that prints a specific report without displaying its preview. The printed report uses custom sorting and includes only the items selected in the List View. The complete description is available in the [How to: Print a Report Without Displaying a Preview (in Reports V2)](https://documentation.devexpress.com/#Xaf/CustomDocument3601) topic.

You can also use the code from this example to access an [XtraReport](https://documentation.devexpress.com/#XtraReports/clsDevExpressXtraReportsUIXtraReporttopic) object and then export or email report content according to tutorials listed in the [Export Reports](https://documentation.devexpress.com/#XtraReports/CustomDocument15796) topic.

![image](https://user-images.githubusercontent.com/14300209/233358203-9518bb1a-cfc7-4a1a-8512-e3d3bd5d60f6.png)

## Files to Review:

* **[InstantPrintReportController.cs](./CS/EFCore/InstantReportEF/InstantReportEF.Module/Controllers/InstantPrintReportController.cs)**
* [BlazorPrintContactsController.cs](./CS/EFCore/InstantReportEF/InstantReportEF.Blazor.Server/Controllers/BlazorPrintContactsController.cs)
* [_Host.cshtml](./CS/EFCore/InstantReportEF/InstantReportEF.Blazor.Server/Pages/_Host.cshtml)
* [WinInstantPrintReportController.cs](./CS/EFCore/InstantReportEF/InstantReportEF.Win/Controllers/WinInstantPrintReportController.cs)

## Documentation

* [Reports V2 Module](https://docs.devexpress.com/eXpressAppFramework/113591/shape-export-print-data/reports/reports-v2-module-overview)
* [How to: Print a Report Without Displaying a Preview (in Reports V2)](https://documentation.devexpress.com/#Xaf/CustomDocument3601)
* [How to: Access Objects Selected in the Current View](https://docs.devexpress.com/eXpressAppFramework/113324/task-based-help/views/how-to-access-objects-selected-in-the-current-view)
* [Data Sorting in Reports V2](https://docs.devexpress.com/eXpressAppFramework/113595/concepts/extra-modules/reports-v2/data-sorting-in-reports-v2)
