using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.Models
{
	public class UserEmail
	{
		public int Id { get; set; }
		public string  Email { get; set; }
		public User user { get; set; }
		public int UserId { get; set; }
	}
}
