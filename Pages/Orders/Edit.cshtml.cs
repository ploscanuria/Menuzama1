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
using Microsoft.AspNetCore.Authorization;

namespace Menuzama1.Pages.Orders
{
    [Authorize(Roles = "Admin")]

    public class EditModel : PageModel
    {
        private readonly Menuzama1.Data.Menuzama1Context _context;

        public EditModel(Menuzama1.Data.Menuzama1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Încarcă comanda și relațiile asociate
            Order = await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.MenuItem)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Order == null)
            {
                return NotFound();
            }

            // Populează dropdown-urile
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "FullName", Order.ClientID);
            ViewData["MenuItemId"] = new SelectList(_context.MenuItems, "Id", "Name", Order.MenuItemId);

            return Page();
        
    }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Repopulează dropdown-urile în caz de eroare
                ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "FullName", Order.ClientID);
                ViewData["MenuItemId"] = new SelectList(_context.MenuItems, "Id", "Name", Order.MenuItemId);
                return Page();
            }

            _context.Attach(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.ID == id);
        }
    }
}
