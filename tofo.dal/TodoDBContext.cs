using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo.dal
{
	public class TodoDBContext : DbContext
	{
		public TodoDBContext()
			: base("name = todoConnection")
		{

		}
		public DbSet<Todo> Todoes { get; set; }
	}
}
