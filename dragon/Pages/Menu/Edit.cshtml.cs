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

namespace dragon.Pages.Menu
{
    public class EditModel : PageModel
    {
        private readonly dragon.Data.dragonContext _context;

        public EditModel(dragon.Data.dragonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dish Dish { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dishes == null)
            {
                return NotFound();
            }

            var dish =  await _context.Dishes.FirstOrDefaultAsync(m => m.DishId == id);
            if (dish == null)
            {
                return NotFound();
            }
            Dish = dish;
           ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "CatName");
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

            _context.Attach(Dish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishExists(Dish.DishId))
                {
                    return NotFound();
                }
                throw; // Rethrow the exception if DishExists returns true
            }

            // Handle file uploads separately outside of the try-catch block
            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                Dish.DishImage = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("/Admin/MenuManager");
        }

        private bool DishExists(int id)
        {
          return (_context.Dishes?.Any(e => e.DishId == id)).GetValueOrDefault();
        }
    }
}
