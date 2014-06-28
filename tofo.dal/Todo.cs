using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace todo.dal
{
	public class Todo
	{
		public Guid Id { get; internal set; }
		public string Text { get; set; }
		public bool Done { get; set; }
	}
}
