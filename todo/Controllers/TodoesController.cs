using System.Web.Mvc;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using todo.dal;
using todo.dal.Autentification;
using todo.Areas.Autentification.Infrastructure;
using System.Linq;
using System.Web.Http.Owin;
using System.Data.Entity;
using System.Web;
using System.Net.Http;
using System.Web.Http;

namespace todo.Controllers
{
	[System.Web.Mvc.AuthorizeAttribute]
	public class TodoesController : ApiController
	{
		TodoDBContext _context = new TodoDBContext();

		private AppUser CurrentUser
		{
			get
			{
				return UserManager.FindByName(HttpContext.Current.User.Identity.Name);
			}
		}
		private AppUserManager UserManager
		{
			get
			{
				return HttpContext.Current.Request.GetOwinContext().GetUserManager<AppUserManager>();
			}
		}

		public IEnumerable<Todo> Get()
		{
			var currentUserId = CurrentUser.Id;
			return _context.Todoes
				.Where(t => t.UserId == currentUserId)
				.ToArray();
		}

		public Todo Post(Todo todo)
		{
			todo.UserId = CurrentUser.Id;
			_context.Todoes.Add(todo);
			_context.SaveChanges();
			return todo;
		}

		public Todo Put(Todo todo)
		{
			todo.UserId = CurrentUser.Id;
			_context.Entry<Todo>(todo).State = EntityState.Modified;
			_context.SaveChanges();
			return todo;
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
			base.Dispose(disposing);
		}
	}
}