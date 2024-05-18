using dragon.Data;
using dragon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace dragon.Pages.Admin
{
    public class MenuManagerModel : PageModel
    {
        private readonly dragon.Data.dragonContext _context;

        public MenuManagerModel(dragonContext context)
        {
            _context = context;
        }
        public IList<Dish> Dish { get; set; }


        public async Task OnGetAsync()
        {
            if (_context.Dishes != null)
            {
                Dish = await _context.Dishes.ToListAsync();
            }
        }
    }
}
