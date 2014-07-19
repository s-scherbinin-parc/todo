using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace todo.Areas.Autentification.Models
{
	public class LoginResponse
	{
		[Required]
		public string ReturnUrl { get; set; }
	}
}