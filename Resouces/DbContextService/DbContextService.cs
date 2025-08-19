using Microsoft.EntityFrameworkCore;
using Resouces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.DbContextService
{
    public class DbContextService : DbContext
    {
        public DbSet<UserData> UserData { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbContextService(DbContextOptions<DbContextService> options) : base(options) { }

}
}
