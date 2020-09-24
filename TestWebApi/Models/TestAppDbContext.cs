using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.Models
{
	public class TestAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserEmail> UserEmails { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-P0FED7H\SQLEXPRESS;Database=Test_DB;Trusted_Connection=True;");
        }
    }
}

