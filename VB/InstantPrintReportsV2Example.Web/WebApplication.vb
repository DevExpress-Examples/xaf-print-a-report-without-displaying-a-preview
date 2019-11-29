Imports System
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.ExpressApp.Web
Imports System.Collections.Generic
'using DevExpress.ExpressApp.Security;

Namespace InstantPrintReportsV2Example.Web
    ' For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/DevExpressExpressAppWebWebApplicationMembersTopicAll
    Partial Public Class InstantPrintReportsV2ExampleAspNetApplication
        Inherits WebApplication

        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
        Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
        Private module3 As InstantPrintReportsV2Example.Module.InstantPrintReportsV2ExampleModule
        Private reportsModuleV21 As DevExpress.ExpressApp.ReportsV2.ReportsModuleV2
        Private reportsAspNetModuleV21 As DevExpress.ExpressApp.ReportsV2.Web.ReportsAspNetModuleV2
        Private module4 As InstantPrintReportsV2Example.Module.Web.InstantPrintReportsV2ExampleAspNetModule

        Public Sub New()
            InitializeComponent()
        End Sub
        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            args.ObjectSpaceProvider = New XPObjectSpaceProvider(args.ConnectionString, args.Connection, True)
        End Sub

        Private Sub InstantPrintReportsV2ExampleAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
            e.Updater.Update()
            e.Handled = True
        End Sub
		
		Protected Overrides Function CreateViewUrlManager() As IViewUrlManager
            Return New ViewUrlManager()
        End Function

        Private Sub InitializeComponent()
            Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
            Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
            Me.reportsModuleV21 = New DevExpress.ExpressApp.ReportsV2.ReportsModuleV2()
            Me.module3 = New InstantPrintReportsV2Example.Module.InstantPrintReportsV2ExampleModule()
            Me.module4 = New InstantPrintReportsV2Example.Module.Web.InstantPrintReportsV2ExampleAspNetModule()
            Me.reportsAspNetModuleV21 = New DevExpress.ExpressApp.ReportsV2.Web.ReportsAspNetModuleV2()
            DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' reportsModuleV21
            ' 
            Me.reportsModuleV21.EnableInplaceReports = True
            Me.reportsModuleV21.ReportDataType = GetType(DevExpress.Persistent.BaseImpl.ReportDataV2)
            ' 
            ' InstantPrintReportsV2ExampleAspNetApplication
            ' 
            Me.ApplicationName = "InstantPrintReportsV2Example"
            Me.Modules.Add(Me.module1)
            Me.Modules.Add(Me.module2)
            Me.Modules.Add(Me.reportsModuleV21)
            Me.Modules.Add(Me.module3)
            Me.Modules.Add(Me.module4)
            Me.Modules.Add(Me.reportsAspNetModuleV21)
            DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
    End Class
End Namespace
