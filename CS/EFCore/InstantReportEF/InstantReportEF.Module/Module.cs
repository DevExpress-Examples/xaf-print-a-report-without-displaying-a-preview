using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.ReportsV2;
using MySolution.Module.BusinessObjects;
using dxTestSolution.Module.DatabaseUpdate;
using InstantReport.Module;

namespace InstantReportEF.Module;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed class InstantReportEFModule : ModuleBase {
    public InstantReportEFModule() {
        // 
        // InstantReportEFModule
        // 
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ReportsV2.ReportsModuleV2));
    }
    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
        ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
        PredefinedReportsUpdater predefinedReportsUpdater =
         new PredefinedReportsUpdater(Application, objectSpace, versionFromDB);
        predefinedReportsUpdater.AddPredefinedReport<ContactReport>("ContactReport", typeof(Contact));
        return new ModuleUpdater[] { updater, new MyUpdater(objectSpace, versionFromDB), predefinedReportsUpdater };
    }
    public override void Setup(XafApplication application) {
        base.Setup(application);
        // Manage various aspects of the application UI and behavior at the module level.
    }
    public override void Setup(ApplicationModulesManager moduleManager) {
        base.Setup(moduleManager);
    }
}
