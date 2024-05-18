using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dragon.Data;
using dragon.Models;
using Microsoft.AspNetCore.Identity;

namespace dragon.Pages.Menu
{
    public class IndexModel : PageModel
    {
        private readonly dragon.Data.dragonContext _context;
        private readonly UserManager<AppUser> _userManager;

        public IndexModel(dragonContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<Cat> Category { get; set; }
        public IList<Dish> Dish { get; set; }
        public async Task OnGetAsync()
        {
            Category = await _context.Category.Include(c => c.Dishes).ToListAsync();

            Dish = await _context.Dishes.ToListAsync();
        }

        public async Task<IActionResult> OnPostBuyAsync(int itemID)
        {
            // Get the current user
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                TempData["ErrorMessage"] = "You need to log in to buy items.";
                return RedirectToPage("/Cart/Index");
            }

            // Find the checkout record for the user
            CheckoutCustomers checkoutCustomers = await _context
                .CheckoutCustomers
                .FirstOrDefaultAsync(c => c.Email == user.Email);

            // Ensure the user has a basket
            if (checkoutCustomers == null)
            {
                // If the user doesn't have a basket, handle this situation accordingly,
                // like creating a new basket for the user or redirecting to an error page.
                // For simplicity, I'll assume creating a new basket.
                checkoutCustomers = new CheckoutCustomers
                {
                    Email = user.Email
                    // Add any other necessary properties
                };
                _context.CheckoutCustomers.Add(checkoutCustomers);
                await _context.SaveChangesAsync();
            }

            // Check if the item is already in the basket
            var item = await _context.BasketItems
                .FirstOrDefaultAsync(b => b.DishId == itemID && b.BasketId == checkoutCustomers.BasketId);

            if (item == null)
            {
                // If the item is not in the basket, add it with quantity 1
                BasketItem newItem = new BasketItem
                {
                    BasketId = checkoutCustomers.BasketId,
                    DishId = itemID,
                    Quantity = 1
                };
                _context.BasketItems.Add(newItem);
            }
            else
            {
                // If the item is already in the basket, increment its quantity
                item.Quantity++;
                _context.BasketItems.Update(item);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Redirect to the same page or wherever appropriate after adding/updating the item
            return RedirectToPage("/Cart/Index");
        }
    }
}
