using System.Web.Mvc;
using System.Web.Optimization;

namespace todo.Areas.Autentification
{
	public class AutentificationAreaRegistration : AreaRegistration
	{
		public override string AreaName
		{
			get
			{
				return "Autentification";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				"Autentification_default",
				"Autentification/{controller}/{action}/{id}",
				new { action = "Index", id = UrlParameter.Optional }
			);

			BundleTable.Bundles.Add(new StyleBundle("~/Autentification/Content/css")
				.Include("~/Areas/Autentification/Content/login.css"));

			BundleTable.Bundles.Add(new ScriptBundle("~/Autentification/Scripts/js")
				.Include("~/Areas/Autentification/Scripts/account.js"));
		}
	}
}