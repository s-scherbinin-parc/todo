using System.Data.Entity;

namespace todo.dal.Autentification
{
	public class IdentityDbInit : DropCreateDatabaseIfModelChanges<TodoDBContext>
	{
		protected override void Seed(TodoDBContext context)
		{
			PerformInitialSetup(context);
			base.Seed(context);
		}

		private void PerformInitialSetup(TodoDBContext context)
		{
		}

	}
}
