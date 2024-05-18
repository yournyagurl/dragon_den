using System.ComponentModel.DataAnnotations;

namespace dragon.Models
{
    public class ItemsOrders
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderNo { get; set; }

        [Required]
        public int DishId { get; set; }

        [Required]

        public int Quantity { get; set; }

        public OrderHistory OrderHistory { get; set; }

        public Dish Dish { get; set; }
    }
}
