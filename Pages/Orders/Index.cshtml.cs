using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Menuzama1.Data;
using Menuzama1.Models;

namespace Menuzama1.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Menuzama1Context _context;

        public IndexModel(Menuzama1Context context)
        {
            _context = context;
        }

        public IList<Order> Order { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } // Parametru pentru căutare

        public async Task OnGetAsync()
        {
            // Preia toate comenzile și relațiile asociate
            var orders = _context.Orders
                .Include(o => o.Client)
                .Include(o => o.MenuItem)
                .AsQueryable();

            // Aplică filtrul de căutare
            if (!string.IsNullOrEmpty(SearchString))
            {
                orders = orders.Where(o => o.Client.FullName.Contains(SearchString));
            }

            // Salvează rezultatele în listă
            Order = await orders.ToListAsync();

            // Salvează filtrul curent în ViewData pentru afișare
            ViewData["CurrentFilter"] = SearchString;
        }
    }
}
