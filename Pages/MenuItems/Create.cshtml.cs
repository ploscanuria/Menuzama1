using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Menuzama1.Data;
using Menuzama1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Menuzama1.Pages.MenuItems
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Menuzama1.Data.Menuzama1Context _context;

        public CreateModel(Menuzama1.Data.Menuzama1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name");
            ViewData["MenuItemTypeID"] = new SelectList(_context.MenuItemTypes, "ID", "Name");


            return Page();
        }

        [BindProperty]
        public MenuItem MenuItem { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MenuItems.Add(MenuItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
