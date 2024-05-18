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
    public class DeleteModel : PageModel
    {
        private readonly dragon.Data.dragonContext _context;

        public DeleteModel(dragon.Data.dragonContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Ad Ad { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ads == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads.FirstOrDefaultAsync(m => m.Id == id);

            if (ad == null)
            {
                return NotFound();
            }
            else 
            {
                Ad = ad;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Ads == null)
            {
                return NotFound();
            }
            var ad = await _context.Ads.FindAsync(id);

            if (ad != null)
            {
                Ad = ad;
                _context.Ads.Remove(Ad);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
