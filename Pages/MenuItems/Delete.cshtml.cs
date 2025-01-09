using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Menuzama1.Data;
using Menuzama1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Menuzama1.Pages.MenuItems
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Menuzama1.Data.Menuzama1Context _context;

        public DeleteModel(Menuzama1.Data.Menuzama1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public MenuItem MenuItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = await _context.MenuItems
           .Include(m => m.Category) // Include relația cu Category
           .Include(m => m.MenuItemType) // Include relația cu MenuItemType
                .FirstOrDefaultAsync(m => m.Id == id);

            if (menuitem == null)
            {
                return NotFound();
            }
            else
            {
                MenuItem = menuitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitem = await _context.MenuItems.FindAsync(id);
            if (menuitem != null)
            {
                MenuItem = menuitem;
                _context.MenuItems.Remove(MenuItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
