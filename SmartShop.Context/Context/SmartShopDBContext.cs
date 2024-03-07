
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using SmartShop.Model.Model;

namespace SmartShop.Context.Context
{
    public class SmartShopDBContext:DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders  { get; set; }
        public virtual DbSet<OrdersItems> OrdersItems  { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=FIREFOX\\AYED2022;Initial Catalog=MarketDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
           .HasIndex(u => u.UserName)
           .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();


        }

    }
}
