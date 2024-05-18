using System.ComponentModel.DataAnnotations;

namespace dragon.Models
{
    public class CheckoutItem
    {
        [Key, Required]
        public int Id { get; set; }
        public int DishId { get; set; }
        public decimal DishPrice { get; set; }
        public string DishName { get; set; }
        public int BasketId { get; set; }
        public int Quantity { get; set; }
    }
}