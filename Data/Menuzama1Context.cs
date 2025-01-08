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

        public DbSet<MenuItem> MenuItems { get; set; }  // Corect, la plural
        public DbSet<Category> Categories { get; set; }  // Corect, la plural
        public DbSet<MenuItemType> MenuItemTypes { get; set; }  // Corect, la plural
      

    }
}
