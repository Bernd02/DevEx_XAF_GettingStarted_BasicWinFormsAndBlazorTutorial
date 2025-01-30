using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.EF;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using Microsoft.Extensions.DependencyInjection;
using SimpleProjectManager.Module.BusinessObjects;

namespace SimpleProjectManager.Module.DatabaseUpdate;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
public class Updater : ModuleUpdater
{
	public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
		base(objectSpace, currentDBVersion)
	{
	}


	public override void UpdateDatabaseAfterUpdateSchema()
	{
		base.UpdateDatabaseAfterUpdateSchema();

		// init Employee
		var empFirstName = "John";
		var empLastName = "Nielsen";

		var employee = this.ObjectSpace.FirstOrDefault<Employee>(emp => emp.FirstName == empFirstName && emp.LastName == empLastName);
		if (employee == null)
		{
			employee = this.ObjectSpace.CreateObject<Employee>();
			employee.FirstName = empFirstName;
			employee.LastName = empLastName;
		}

		// init ProjectTask
		var projTaskSubject = "TODO: Conditional UI Customization";

		var projectTask = this.ObjectSpace.FirstOrDefault<ProjectTask>(pTask => pTask.Subject == projTaskSubject);
		if (projectTask == null)
		{
			projectTask = this.ObjectSpace.CreateObject<ProjectTask>();
			projectTask.Subject = projTaskSubject;
			projectTask.Status = ProjectTaskStatus.InProgress;
			projectTask.AssignedTo = employee;
			projectTask.StartDate = new DateTime(2023, 1, 27);
			projectTask.Notes = "OVERVIEW: http://www.devexpress.com/Products/NET/Application_Framework/features_appearance.xml";
		}

		// init Project
		var projName = "DevExpress XAF Features Overview";

		var project = this.ObjectSpace.FirstOrDefault<Project>(p => p.Name == projName);
		if (project == null)
		{
			project = this.ObjectSpace.CreateObject<Project>();
			project.Name = projName;
			project.Manager = employee;
			project.ProjectTasks.Add(projectTask);
		}

		// init Customer
		var customerFirstName = "Ann";
		var customerLastName = "Devon";

		var customer = this.ObjectSpace.FirstOrDefault<Customer>(customer => customer.FirstName == customerFirstName && customer.LastName == customerLastName);
		if (customer == null)
		{
			customer = this.ObjectSpace.CreateObject<Customer>();
			customer.FirstName = customerFirstName;
			customer.LastName = customerLastName;
			customer.Company = "Eastern Connection";
		}

		ObjectSpace.CommitChanges(); //Uncomment this line to persist created object(s).
	}

	public override void UpdateDatabaseBeforeUpdateSchema()
	{
		base.UpdateDatabaseBeforeUpdateSchema();
	}
}
