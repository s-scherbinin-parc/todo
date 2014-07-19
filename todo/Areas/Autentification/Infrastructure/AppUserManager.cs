using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using todo.dal;
using todo.dal.Autentification;

namespace todo.Areas.Autentification.Infrastructure
{
	public class AppUserManager : UserManager<AppUser>
	{
		public AppUserManager(IUserStore<AppUser> store)
			: base(store)
		{
		}

		public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
		{
			TodoDBContext db = context.Get<TodoDBContext>();
			AppUserManager manager = new AppUserManager(new UserStore<AppUser>(db));
			return manager;
		}
	}
}