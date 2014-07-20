using System;
using System.Web;
using System.Web.Optimization;

namespace todo
{
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/app").Include(
						"~/Content/controller.js"));

			bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
						"~/Content/vendor/angular/angular.js",
						"~/Content/vendor/angular-route/angular-route.js",
						"~/Content/vendor/angular-resource/angular-resource.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
			//BundleTable.EnableOptimizations = true;
		}
	}
}