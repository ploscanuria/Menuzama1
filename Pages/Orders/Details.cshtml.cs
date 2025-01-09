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
    public class DetailsModel : PageModel
    {
        private readonly Menuzama1.Data.Menuzama1Context _context;

        public DetailsModel(Menuzama1.Data.Menuzama1Context context)
        {
            _context = context;
        }

        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders
           .Include(o => o.Client)       // Include relația cu Client
           .Include(o => o.MenuItem)    // Include relația cu MenuItem
           .FirstOrDefaultAsync(m => m.ID == id);
            if (Order == null)
            {
                return NotFound();
            }
            else
            {
                Order = Order;
            }
            return Page();
        }
    }
}
