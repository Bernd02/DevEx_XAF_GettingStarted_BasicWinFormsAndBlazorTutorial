using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProjectManager.Module.BusinessObjects;

[NavigationItem(Constants.NavigationItems.MARKETING)]
public class Testimonial : BaseObject
{
	[FieldSize(FieldSizeAttribute.Unlimited)]
	public virtual string Quote { get; set; }

	[FieldSize(512)]
	public virtual string Highlight { get; set; }

	[VisibleInListView(false)]
	public virtual DateTime CreatedOn { get; set; }

	public virtual string Tags { get; set; }

	public virtual IList<Customer> Customers { get; set; } = new ObservableCollection<Customer>();
}
