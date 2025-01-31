using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.Base;
using System.ComponentModel;

namespace SimpleProjectManager.Module;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed class SimpleProjectManagerModule : ModuleBase
{
	public SimpleProjectManagerModule()
	{
		//
		// SimpleProjectManagerModule
		//
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule));
	}


	public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
	{
		ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
		return new ModuleUpdater[] { updater };
	}

	public override void Setup(XafApplication application)
	{
		base.Setup(application);
		// Manage various aspects of the application UI and behavior at the module level.
	}
}
