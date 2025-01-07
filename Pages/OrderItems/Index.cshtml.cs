﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Menuzama1.Data;
using Menuzama1.Models;

namespace Menuzama1.Pages.OrderItems
{
    public class IndexModel : PageModel
    {
        private readonly Menuzama1.Data.Menuzama1Context _context;

        public IndexModel(Menuzama1.Data.Menuzama1Context context)
        {
            _context = context;
        }

        public IList<OrderItem> OrderItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            OrderItem = await _context.OrderItems
                .Include(o => o.MenuItem)
                .Include(o => o.Order).ToListAsync();
        }
    }
}