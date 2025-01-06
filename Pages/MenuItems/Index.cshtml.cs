﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Menuzama1.Data;
using Menuzama1.Models;

namespace Menuzama1.Pages.MenuItems
{
    public class IndexModel : PageModel
    {
        private readonly Menuzama1.Data.Menuzama1Context _context;

        public IndexModel(Menuzama1.Data.Menuzama1Context context)
        {
            _context = context;
        }

        public IList<MenuItem> MenuItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            MenuItem = await _context.MenuItem
                 .Include(m => m.Category)
                .Include(m => m.MenuItemType)
                .ToListAsync();
        }
    }
}