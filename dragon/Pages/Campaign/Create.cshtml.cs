using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using dragon.Data;
using dragon.Models;

namespace dragon.Pages.Campaign
{
    public class CreateModel : PageModel
    {
        private readonly dragon.Data.dragonContext _context;

        public CreateModel(dragon.Data.dragonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Ad Ad { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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


            _context.Ads.Add(Ad);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
