using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Menuzama1.Data;
using Menuzama1.Models;

namespace Menuzama1.Pages.MenuItems
{
    public class IndexModel : PageModel
    {
        private readonly Menuzama1.Data.Menuzama1Context _context;

        public IndexModel(Menuzama1.Data.Menuzama1Context context)
        {
            _context = context;
        }

        public IList<MenuItem> MenuItem { get; set; } = default!;
        public SelectList Categories { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; }

        public async Task OnGetAsync()
        {
            // Obține toate categoriile pentru dropdown
            var categoriesQuery = _context.Category.Select(c => c.Name);

            // Creează interogarea pentru articolele din meniu
            var menuItems = _context.MenuItem
                .Include(m => m.Category)
                .Include(m => m.MenuItemType)
                .AsQueryable(); // Transformă în IQueryable

            // Aplică filtrarea dacă există o categorie selectată
            if (!string.IsNullOrEmpty(SelectedCategory))
            {
                menuItems = menuItems.Where(m => m.Category.Name == SelectedCategory);
            }

            // Populează modelul
            Categories = new SelectList(await categoriesQuery.Distinct().ToListAsync());
            MenuItem = await menuItems.ToListAsync();
        }

    }
}
