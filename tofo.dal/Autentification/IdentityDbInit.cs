using System.Data.Entity;

namespace todo.dal.Autentification
{
	public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
	{
		protected override void Seed(AppIdentityDbContext context)
		{
			PerformInitialSetup(context);
			base.Seed(context);
		}

		private void PerformInitialSetup(AppIdentityDbContext context)
		{
		}

	}
}
