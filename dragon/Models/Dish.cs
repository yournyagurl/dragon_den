using System.ComponentModel.DataAnnotations;

namespace dragon.Models
{
    public class Dish
    {
        public int DishId { get; set; }


        [Required]
        public string DishName { get; set; }

        [Required]
        public string ChineseTranslation { get; set; }


        [Required]
        public decimal DishPrice { get; set; }

        [Required]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Cat Category { get; set; }

        [Display(Name = "Dish Image (Please ensure image is 320px X 320 px)")]
        public byte[] DishImage { get; set; }

        public string DishImageDesc { get; set; }

        public bool IsSpecial { get; set; }

        public bool Availability { get; set; }

        public static implicit operator Dish(List<Dish> v)
        {
            throw new NotImplementedException();
        }
    }
}
