using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using todo.dal.Autentification;

namespace todo.dal
{
	public class TodoDBContext : IdentityDbContext<AppUser>
	{
		static TodoDBContext()
		{
			Database.SetInitializer<TodoDBContext>(new IdentityDbInit());
		}

		public static TodoDBContext Create()
		{
			return new TodoDBContext();
		}

		public TodoDBContext()
			: base("name = todoConnection")
		{

		}

		public DbSet<Todo> Todoes { get; set; }
	}

	public class MyConfiguration : DbConfiguration
	{
		public MyConfiguration()
		{
			AddDependencyResolver(new SingletonDependencyResolver<IManifestTokenResolver>(new SqlAzureManifestTokenResolver()));
		}
	}

	public class SqlAzureManifestTokenResolver : IManifestTokenResolver
	{
		public string ResolveManifestToken(DbConnection connection)
		{
			// customize your logic here if needed
			if (connection is SqlConnection)
			{
				return "2012.Azure";
			}
			else
			{
				return new DefaultManifestTokenResolver().ResolveManifestToken(connection);
			}
		}
	}
}
