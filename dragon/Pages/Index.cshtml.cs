using dragon.Data;
using dragon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace dragon.Pages
{
    public class IndexModel : PageModel
    {
        private readonly dragonContext _context;

        public IndexModel(dragonContext context)
        {
            _context = context;
        }

        public IList<Ad> Ad { get; set; }
        public IList<Dish> Dish { get; set; }

        public async Task OnGetAsync()
        {

            Ad = await _context.Ads.ToListAsync();


            Dish = await _context.Dishes.ToListAsync();
        }
    }
}
