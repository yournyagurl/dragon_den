using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dragon.Data;
using dragon.Models;

namespace dragon.Pages.Campaign
{
    public class IndexModel : PageModel
    {
        private readonly dragon.Data.dragonContext _context;

        public IndexModel(dragon.Data.dragonContext context)
        {
            _context = context;
        }

        public IList<Ad> Ad { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Ads != null)
            {
                Ad = await _context.Ads.ToListAsync();
            }
        }
    }
}
