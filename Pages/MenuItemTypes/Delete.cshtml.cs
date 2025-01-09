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

namespace Menuzama1.Pages.MenuItemTypes
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
        public MenuItemType MenuItemType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitemtype = await _context.MenuItemTypes.FirstOrDefaultAsync(m => m.ID == id);

            if (menuitemtype == null)
            {
                return NotFound();
            }
            else
            {
                MenuItemType = menuitemtype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuitemtype = await _context.MenuItemTypes.FindAsync(id);
            if (menuitemtype != null)
            {
                MenuItemType = menuitemtype;
                _context.MenuItemTypes.Remove(MenuItemType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
