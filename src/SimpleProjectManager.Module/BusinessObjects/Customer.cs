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
public class Customer : BaseObject
{
	public virtual string FirstName { get; set; }
	public virtual string LastName { get; set; }

	[FieldSize(255)]
	public virtual string Email { get; set; }

	public virtual string Company { get; set; }

	public virtual string Occupation { get; set; }

	public virtual IList<Testimonial> Testimonials { get; set; } = new ObservableCollection<Testimonial>();

	[VisibleInListView(false)]
	[ImageEditor(ListViewImageEditorCustomHeight = 75, DetailViewImageEditorFixedHeight = 150)]
	public virtual MediaDataObject Photo { get; set; }
}
