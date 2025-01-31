using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using SimpleProjectManager.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleProjectManager.Module.Controllers;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ViewController.
public partial class ProjectTaskController : ViewController
{
	// Use CodeRush to create Controllers and Actions with a few keystrokes.
	// https://docs.devexpress.com/CodeRushForRoslyn/403133/
	public ProjectTaskController()
	{
		InitializeComponent();
		// Target required Views (via the TargetXXX properties) and create their Actions.

		// Specify the type of Controller in any type of View.
		TargetObjectType = typeof(ProjectTask);

		// Activate the Controller in any type of View.
		TargetViewType = ViewType.Any;

		var markCompletedAction = new SimpleAction(this, "MarkCompleted", PredefinedCategory.RecordEdit);
		markCompletedAction.TargetObjectsCriteria = (CriteriaOperator.FromLambda<ProjectTask>(projTask => projTask.Status != ProjectTaskStatus.Completed)).ToString();
		markCompletedAction.ConfirmationMessage = "Are you sure you want to mark the selected task(s) as 'Completed'?";
		markCompletedAction.ImageName = "State_Task_Completed";
		markCompletedAction.SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects;
		markCompletedAction.Execute += (s, e) =>
		{
			foreach (ProjectTask task in e.SelectedObjects)
			{
				task.EndDate = DateTime.Now;
				task.Status = ProjectTaskStatus.Completed;
				View.ObjectSpace.SetModified(task);
			}
			View.ObjectSpace.CommitChanges();
			View.ObjectSpace.Refresh();
		};
	}


	protected override void OnActivated()
	{
		base.OnActivated();
		// Perform various tasks depending on the target View.
	}

	protected override void OnViewControlsCreated()
	{
		base.OnViewControlsCreated();
		// Access and customize the target View control.
	}

	protected override void OnDeactivated()
	{
		// Unsubscribe from previously subscribed events and release other references and resources.
		base.OnDeactivated();
	}
}
