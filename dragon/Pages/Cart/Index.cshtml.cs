using dragon.Data;
using dragon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace dragon.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly dragonContext _context;

        public IndexModel(dragonContext context)
        {
            _context = context;
        }

        public IList<BasketItem> BasketItems { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsCartEmpty { get; set; }

        public async Task OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                BasketItems = new List<BasketItem>();
                IsCartEmpty = true;
                return;
            }

            BasketItems = await _context.BasketItems
                .Include(b => b.Dish)
                .ToListAsync();

            TotalPrice = BasketItems.Sum(b => b.Quantity * b.Dish.DishPrice);

            IsCartEmpty = BasketItems.Count == 0;
        }


        public async Task<IActionResult> OnPostIncrementAsync(int dishId, int basketId)
        {
            var basketItem = await _context.BasketItems.FindAsync(dishId, basketId);
            if (basketItem != null)
            {
                basketItem.Quantity++;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDecrementAsync(int dishId, int basketId)
        {
            var basketItem = await _context.BasketItems.FindAsync(dishId, basketId);
            if (basketItem != null && basketItem.Quantity > 1)
            {
                basketItem.Quantity--;
                await _context.SaveChangesAsync();
            }
            else if (basketItem != null && basketItem.Quantity == 1)
            {
                _context.BasketItems.Remove(basketItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
