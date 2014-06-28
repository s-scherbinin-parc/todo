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
		public DbSet<Todo> Todoes { get; set; }
	}
}
