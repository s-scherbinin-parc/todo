using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using todo.dal;

namespace todo.Controllers
{
	[Authorize]
	public class TodoesController : ApiController
	{
		TodoDBContext _context = new TodoDBContext();

		public IEnumerable<Todo> Get()
		{
			return _context.Todoes.ToArray();
		}

		public Todo Post(Todo todo)
		{
			_context.Todoes.Add(todo);
			_context.SaveChanges();
			return todo;
		}

		public Todo Put(Todo todo)
		{
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