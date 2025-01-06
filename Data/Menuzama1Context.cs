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
        public Menuzama1Context (DbContextOptions<Menuzama1Context> options)
            : base(options)
        {
        }

        public DbSet<Menuzama1.Models.MenuItem> MenuItem { get; set; } = default!;
        public DbSet<Menuzama1.Models.Category> Category { get; set; } = default!;
        public DbSet<Menuzama1.Models.MenuItemType> MenuItemType { get; set; } = default!;
    }
}
