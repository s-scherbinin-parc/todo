using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using todo.dal;
using System.Linq;

namespace todo.Tests
{
	[TestClass]
	public class DalTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			using (var context = new TodoDBContext())
			{
				context.Todoes.Add(new Todo() { Text = "Помыть посуду", Done = false });
				context.SaveChanges();
			}

			using (var context = new TodoDBContext())
			{
				var todo = context.Todoes.FirstOrDefault(t => t.Text == "Помыть посуду");
				Assert.IsNotNull(todo);
				Assert.AreNotEqual(Guid.Empty, todo.Id);
				context.Todoes.Remove(todo);
				context.SaveChanges();
			}


		}
	}
}
