using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dragon.Data;
using dragon.Models;

namespace dragon.Pages.Menu
{
    public class DetailsModel : PageModel
    {
        private readonly dragon.Data.dragonContext _context;

        public DetailsModel(dragon.Data.dragonContext context)
        {
            _context = context;
        }

      public Dish Dish { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dishes == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes.FirstOrDefaultAsync(m => m.DishId == id);
            if (dish == null)
            {
                return NotFound();
            }
            else 
            {
                Dish = dish;
            }
            return Page();
        }
    }
}
