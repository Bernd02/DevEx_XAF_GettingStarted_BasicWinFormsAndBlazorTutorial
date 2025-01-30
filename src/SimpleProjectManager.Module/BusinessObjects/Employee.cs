using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProjectManager.Module.BusinessObjects;

[DefaultProperty(nameof(FullName))]
public class Employee : BaseObject
{
	public virtual string FirstName { get; set; }
	public virtual string LastName { get; set; }
	public string FullName
	{
		get => ObjectFormatter.Format(
			$"{nameof(this.FirstName)} {nameof(this.LastName)}",
			this,
			EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty);
	}
}
