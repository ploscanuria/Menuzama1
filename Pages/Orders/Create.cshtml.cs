using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Menuzama1.Data;
using Menuzama1.Models;

namespace Menuzama1.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly Menuzama1Context _context;

        public CreateModel(Menuzama1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }

        // Proprietăți pentru dropdown-uri
        public SelectList Clients { get; set; }
        public SelectList MenuItems { get; set; }

        public IActionResult OnGet()
        {
            // Populează dropdown-urile
            Clients = new SelectList(_context.Clients, "ID", "FullName");
            MenuItems = new SelectList(_context.MenuItems, "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Repopulează dropdown-urile în caz de eroare
            Clients = new SelectList(_context.Clients, "ID", "FullName");
            MenuItems = new SelectList(_context.MenuItems, "Id", "Name");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
