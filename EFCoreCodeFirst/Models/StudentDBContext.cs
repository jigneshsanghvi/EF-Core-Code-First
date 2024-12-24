using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using EFCoreCodeFirst.Models;

namespace EFCoreCodeFirst.Models
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set;}
        public DbSet<Product> Products { get; set; }

        public DbSet<Test3> Test3s { get; set; }
        public DbSet<Test4> Test4s { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        
        //public DbSet<User> User { get; set; } = default!;
        //public DbSet<User> Users { get; set;}
        //public DbSet<Role> Roles { get; set;}
    }
}
