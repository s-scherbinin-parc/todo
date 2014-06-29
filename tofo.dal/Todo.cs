using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace todo.dal
{
	public class Todo
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		public string Text { get; set; }
		public bool Done { get; set; }
	}
}
