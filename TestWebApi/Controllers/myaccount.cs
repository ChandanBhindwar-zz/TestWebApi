using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class myaccount : ControllerBase
	{
		// GET: api/<myaccount>
		[HttpGet("getUsers")]
		public dynamic Get()
		{
			try
			{
				using (var context = new TestAppDbContext())
				{
					var users = context.Users.Select(u => new
					{
						u.Id,
						u.Email,
						u.Name,
						u.Phone,
						u.DateOfBirth,
						u.UserEmails
					}).ToList();
					return users;
				}
			}
			catch (Exception ex)
			{

				return null;
			}
		}

		// GET api/<myaccount>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		[HttpPost("postUser")]
		public bool PostUser()
		{
			try
			{
				var file0 = Request.Form;
				var file1 = Request.Form.Files["myFile"];
				var file2 = Request.Form.Files["formData"];
				var file = Request.Form.Files[0];
				var folderName = Path.Combine("Resources", "Images");
				var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
				if (file.Length > 0)
				{
					var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
					var fullPath = Path.Combine(pathToSave, fileName);
					var dbPath = Path.Combine(folderName, fileName);
					using (var stream = new FileStream(fullPath, FileMode.Create))
					{
						file.CopyTo(stream);
					}
					return true;
				}
				else
				{
					return false;
				}
				
			}
			catch (Exception ex)
			{

				return false;
			}
		}

			// POST api/<myaccount>
			[HttpPost("postUser1")]
		public bool PostUser1([FromBody] RegisterBinding data)
		{
			try
			{
				using (var context = new TestAppDbContext())
				{
					User user = new User();
					user.Name = data.name;
					user.Email = data.email;
					user.Password = data.password;
					user.Phone = data.phone;
					user.DateOfBirth = data.dateOfBirth;
					user.Image = data.image.FileName;
					context.Users.Add(user);
					context.SaveChanges();
					return true;
				}
			}
			catch (Exception ex)
			{

				return false;
			}
		}

		[HttpPost("postAddEmail")]
		public bool PostAddEmail([FromBody] EmailBinding data)
		{
			try
			{
				using (var context = new TestAppDbContext())
				{
					UserEmail user = new UserEmail();
					user.Email = data.email;
					user.UserId = data.userId;
					context.UserEmails.Add(user);
					context.SaveChanges();
					return true;
				}
			}
			catch (Exception ex)
			{

				return false;
			}
		}

		[HttpPost("postUserLogin")]
		public bool PostUserLogin([FromBody] UserLoginBinding data)
		{
			try
			{
				using (var context = new TestAppDbContext())
				{
					var user = context.Users.FirstOrDefault(u => u.Email == data.email && u.Password == data.password);

					if (user != null)
					{
						return true;
					}
					else
					{
						return false;
					}

				}
			}
			catch (Exception ex)
			{

				return false;
			}
		}

		// PUT api/<myaccount>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<myaccount>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
