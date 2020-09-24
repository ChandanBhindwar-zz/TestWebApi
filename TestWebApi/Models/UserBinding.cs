using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.Models
{
	public class RegisterBinding
	{
		public int id { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public string phone { get; set; }
		public string password { get; set; }
		public DateTime? dateOfBirth { get; set; }
		public IFormFile image { get; set; }
	}

	public class UserLoginBinding
	{
		public string email { get; set; }
		public string password { get; set; }
	}
	public class EmailBinding
	{
		public string email { get; set; }
		public int userId { get; set; }
	}
}
