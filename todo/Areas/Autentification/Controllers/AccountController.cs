using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using todo.Areas.Autentification.Infrastructure;
using todo.Areas.Autentification.Models;
using todo.dal.Autentification;

namespace todo.Areas.Autentification.Controllers
{
	public class AccountController : Controller
	{
		#region Filds
		private AppUserManager _userManager;
		#endregion

		#region .ctor

		public AccountController()
		{
		}

		public AccountController(AppUserManager userManager)
		{
			UserManager = userManager;
		}

		#endregion

		#region Properties

		public AppUserManager UserManager
		{
			get
			{
				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

		private IAuthenticationManager AuthManager
		{
			get
			{
				return HttpContext.GetOwinContext().Authentication;
			}
		}

		#endregion

		#region Actions

		[AllowAnonymous]
		public ActionResult Login(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				var user = await UserManager.FindAsync(model.Email, model.Password);
				if (user != null)
				{
					await SignInAsync(user, true);
					return Redirect(returnUrl);
				}
				else
				{
					ModelState.AddModelError("", "Invalid username or password.");
				}
			}

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult LogOff()
		{
			AuthManager.SignOut();
			return RedirectToAction("Index", "Home");
		}

		private async Task SignInAsync(AppUser user, bool isPersistent)
		{
			AuthManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
			ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
			AuthManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, ident);
		}

		#endregion
	}
}