using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using dragon.Data;
using dragon.Models;

namespace dragon.Pages.Menu
{
    public class CreateModel : PageModel
    {
        private readonly dragon.Data.dragonContext _context;

        public CreateModel(dragon.Data.dragonContext context)
        {
            _context = context;
        }

        public List<Cat> Category { get; set; }
        public IActionResult OnGet()
        {
            Category = _context.Category.ToList();
            ViewData["Categories"] = Category;
            return Page();
        }

        [BindProperty]
        public Dish Dish { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Dishes == null || Dish == null)
            {
                return Page();
            }
            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                Dish.DishImage = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }
              

            _context.Dishes.Add(Dish);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
