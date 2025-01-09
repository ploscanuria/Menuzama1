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

        // Entitățile gestionate de contextul bazei de date
        public DbSet<MenuItem> MenuItems { get; set; }  // Elemente individuale de meniu
        public DbSet<Category> Categories { get; set; }  // Categorii de meniu
        public DbSet<MenuItemType> MenuItemTypes { get; set; }  // Tipuri de elemente de meniu
        public DbSet<Order> Orders { get; set; }  // Comenzi plasate de clienți
        public DbSet<Client> Clients { get; set; }  // Informații despre clienți

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Exemplu de configurare a unei relații cu Fluent API
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)  // Fiecare comandă are un client
                .WithMany(c => c.Orders)  // Un client poate avea mai multe comenzi
                .HasForeignKey(o => o.ClientID);  // Cheia străină în tabela Order

            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Category)  // Fiecare element de meniu aparține unei categorii
                .WithMany(c => c.MenuItems)  // O categorie poate avea mai multe elemente de meniu
                .HasForeignKey(m => m.CategoryID);  // Cheia străină în tabela MenuItem

            // Adaugă aici orice alte configurări specifice necesare
        }
    }
}
