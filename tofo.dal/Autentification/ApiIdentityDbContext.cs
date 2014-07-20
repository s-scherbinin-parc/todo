using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace todo.dal.Autentification
{
	public class AppIdentityDbContext : IdentityDbContext<AppUser>
	{
		public AppIdentityDbContext() : base("todoConnection")
		{ }

		static AppIdentityDbContext()
		{
			Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
		}

		public static AppIdentityDbContext Create()
		{
			return new AppIdentityDbContext();
		}
	}
}