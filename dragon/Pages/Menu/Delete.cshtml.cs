﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly dragon.Data.dragonContext _context;

        public DeleteModel(dragon.Data.dragonContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Dishes == null)
            {
                return NotFound();
            }
            var dish = await _context.Dishes.FindAsync(id);

            if (dish != null)
            {
                Dish = dish;
                _context.Dishes.Remove(Dish);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
