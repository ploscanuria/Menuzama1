﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Menuzama1.Data;
using Menuzama1.Models;

namespace Menuzama1.Pages.MenuItemTypes
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
            return Page();
        }

        [BindProperty]
        public MenuItemType MenuItemType { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MenuItemTypes.Add(MenuItemType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
