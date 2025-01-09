using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Menuzama1.Data;
using Menuzama1.Models;

namespace Menuzama1.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly Menuzama1.Data.Menuzama1Context _context;

        public IndexModel(Menuzama1.Data.Menuzama1Context context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            // Obține lista clienților din baza de date
            Client = await _context.Clients.Select(client => new Client
            {
                ID = client.ID,
                FullName = client.FullName ?? "Unknown", // Înlocuiește valorile NULL cu valori implicite
                Adress = client.Adress ?? "Unknown Address",
                Email = client.Email ?? "Unknown Email",
                Phone = client.Phone ?? "Unknown Phone"
            }).ToListAsync();
        }
    }
 }

