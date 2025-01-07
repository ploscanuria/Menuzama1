using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Menuzama1.Data;
using Menuzama1.Models;

namespace Menuzama1.Pages.OrderItems
{
    public class CreateModel : PageModel
    {
        private readonly Menuzama1.Data.Menuzama1Context _context;

        public CreateModel(Menuzama1.Data.Menuzama1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MenuItemID"] = new SelectList(_context.MenuItem, "Id", "Description");
        ViewData["OrderID"] = new SelectList(_context.Orders, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public OrderItem OrderItem { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrderItems.Add(OrderItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
