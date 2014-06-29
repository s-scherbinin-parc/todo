using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using todo.dal;

namespace todo.Controllers
{
	public class TodoesController : ApiController
	{
		public IEnumerable<Todo> Get()
		{
			return new TodoDBContext().Todoes.ToArray();
		}
	}
}