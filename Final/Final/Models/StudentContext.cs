using Microsoft.EntityFrameworkCore;
using System;

namespace Final.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
