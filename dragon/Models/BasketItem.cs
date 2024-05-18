using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dragon.Models
{
    public class BasketItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DishId { get; set; }

        [ForeignKey("DishId")]
        public Dish Dish { get; set; }  // Navigation property

        [Required]
        public int BasketId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
