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

namespace Menuzama1.Pages.MenuItemTypes
{
    public class EditModel : PageModel
    {
        private readonly Menuzama1.Data.Menuzama1Context _context;

        public EditModel(Menuzama1.Data.Menuzama1Context context)
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

            var menuitemtype =  await _context.MenuItemTypes.FirstOrDefaultAsync(m => m.ID == id);
            if (menuitemtype == null)
            {
                return NotFound();
            }
            MenuItemType = menuitemtype;
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

            _context.Attach(MenuItemType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemTypeExists(MenuItemType.ID))
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

        private bool MenuItemTypeExists(int id)
        {
            return _context.MenuItemTypes.Any(e => e.ID == id);
        }
    }
}
