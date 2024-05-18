using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dragon.Data;
using dragon.Models;

namespace dragon.Pages.Campaign
{
    public class EditModel : PageModel
    {
        private readonly dragon.Data.dragonContext _context;

        public EditModel(dragon.Data.dragonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ad Ad { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ads == null)
            {
                return NotFound();
            }

            var ad =  await _context.Ads.FirstOrDefaultAsync(m => m.Id == id);
            if (ad == null)
            {
                return NotFound();
            }
            Ad = ad;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                Ad.AdImage = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }


            _context.Attach(Ad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdExists(Ad.Id))
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

        private bool AdExists(int id)
        {
          return _context.Ads.Any(e => e.Id == id);
        }
    }
}
