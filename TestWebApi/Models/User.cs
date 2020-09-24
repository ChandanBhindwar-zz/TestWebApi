using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Password { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string Image { get; set; }
		public List<UserEmail> UserEmails { get; set; }
	}
}
