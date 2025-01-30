using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProjectManager.Module.BusinessObjects;

[NavigationItem(Constants.NavigationItems.PLANNING)]
[DefaultProperty(nameof(Name))]
public class Project : BaseObject
{
	public virtual string Name { get; set; }
	public virtual Employee Manager { get; set; }

	[StringLength(4096)]
	public virtual string Description { get; set; }

	public virtual IList<ProjectTask> ProjectTasks { get; set; } = new ObservableCollection<ProjectTask>();
}
