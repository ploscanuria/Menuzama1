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

namespace Menuzama1.Pages.OrderItems
{
    public class EditModel : PageModel
    {
        private readonly Menuzama1.Data.Menuzama1Context _context;

        public EditModel(Menuzama1.Data.Menuzama1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderItem OrderItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderitem =  await _context.OrderItems.FirstOrDefaultAsync(m => m.ID == id);
            if (orderitem == null)
            {
                return NotFound();
            }
            OrderItem = orderitem;
           ViewData["MenuItemID"] = new SelectList(_context.MenuItem, "Id", "Description");
           ViewData["OrderID"] = new SelectList(_context.Orders, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OrderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemExists(OrderItem.ID))
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

        private bool OrderItemExists(int id)
        {
            return _context.OrderItems.Any(e => e.ID == id);
        }
    }
}
