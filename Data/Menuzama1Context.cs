using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Menuzama1.Models;

namespace Menuzama1.Data
{
    public class Menuzama1Context : DbContext
    {
        public Menuzama1Context(DbContextOptions<Menuzama1Context> options)
            : base(options)
        {
        }

        public DbSet<Menuzama1.Models.MenuItem> MenuItem { get; set; } = default!;
        public DbSet<Menuzama1.Models.Category> Category { get; set; } = default!;
        public DbSet<Menuzama1.Models.MenuItemType> MenuItemType { get; set; } = default!;
        public DbSet<Menuzama1.Models.Order> Orders { get; set; } = default!;
        public DbSet<Menuzama1.Models.OrderItem> OrderItems { get; set; } = default!;
        public DbSet<Menuzama1.Models.User> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurare relație many-to-one între Order și User
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserID);

            // Configurare relație many-to-one între OrderItem și Order
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderID);

            // Configurare relație many-to-one între OrderItem și MenuItem
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.MenuItem)
                .WithMany()
                .HasForeignKey(oi => oi.MenuItemID);
        }
    }
}
