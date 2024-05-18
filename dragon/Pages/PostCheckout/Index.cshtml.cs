using System.Collections.Generic;
using System.Threading.Tasks;
using dragon.Data;
using dragon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace dragon.Pages.PostCheckout
{
    public class IndexModel : PageModel
    {
        private readonly dragonContext _dragonContext;

        public OrderHistory orderHistory {  get; set; }

        public IndexModel(dragonContext dragonContext)
        {
            _dragonContext = dragonContext;
        }

        public IActionResult OnGet()
        {
            orderHistory = _dragonContext.OrderHistorys.OrderByDescending(o => o.OrderNo).FirstOrDefault();

            if (orderHistory == null )
            {
                return NotFound();
            }

            return Page();
        }
    }
}