using ECommerceTask.Domain.Entities;
using ECommerceTask.Infrastructre.Presistance.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Infrastructre
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<User>(new UserConfigurations());
            modelBuilder.ApplyConfiguration<Product>(new ProductCpnfiguration());
            modelBuilder.ApplyConfiguration<RefreshToken>(new RefreshTokenConfigurations());
            base.OnModelCreating(modelBuilder);
        }
    }
}
