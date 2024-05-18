using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dragon.Data;
using dragon.Migrations;
using dragon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace dragon.Pages.CheckoutPage
{
    public class IndexModel : PageModel
    {
        private readonly dragonContext _db;
        private readonly UserManager<AppUser> _userManager;

        public IList<CheckoutItem> Items { get; private set; }
        public decimal Total { get; private set; }
        public long AmountPayable { get; private set; }
        public bool IsUserLoggedIn { get; private set; }

        public OrderHistory Order = new OrderHistory();

        public IndexModel(dragonContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                IsUserLoggedIn = false;
                return;
            }

            IsUserLoggedIn = true;

            var checkoutCustomer = await _db.CheckoutCustomers.FirstOrDefaultAsync(c => c.Email == user.Email);
            if (checkoutCustomer == null)
            {
                //    Handle scenario where checkout customer is not found
                return;
            }

            Items = await _db.CheckoutItems.FromSqlRaw(
            "SELECT Dish.DishId, Dish.DishPrice, Dish.DishName, " +
            "BasketItems.BasketId, BasketItems.Quantity " +
            "FROM Dish " +
            "INNER JOIN BasketItems ON Dish.DishId = BasketItems.DishId " +
            "WHERE BasketItems.BasketId = {0}", checkoutCustomer.BasketId)
            .Select(x => new CheckoutItem
            {
                DishId = x.DishId,
                DishPrice = x.DishPrice,
                DishName = x.DishName,
                BasketId = x.BasketId,
                Quantity = x.Quantity
            })
            .ToListAsync();

            Total = Items.Sum(item => item.DishPrice * item.Quantity);
            AmountPayable = (long)Total;
        }

        public async Task<IActionResult> OnPostBuyAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            var order = new OrderHistory
            {
                Email = user.Email
            };

            _db.OrderHistorys.Add(order);

            CheckoutCustomers checkoutCustomer = await _db.CheckoutCustomers.FirstOrDefaultAsync(c => c.Email == user.Email);
            if (checkoutCustomer == null)
            {
                // Handle scenario where checkout customer is not found
                return RedirectToPage("/Error");
            }

            var basketItems = await _db.BasketItems
                .Where(item => item.BasketId == checkoutCustomer.BasketId)
                .ToListAsync();

            foreach (var item in basketItems)
            {
                var orderItem = new ItemsOrders
                {
                    OrderNo = order.OrderNo,
                    DishId = item.DishId,
                    Quantity = item.Quantity,
                };

                _db.BasketItems.Remove(item);
            }

            await _db.SaveChangesAsync();

            return RedirectToPage("/PostCheckout/Index");
        }
    }
}
