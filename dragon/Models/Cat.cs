using System.ComponentModel.DataAnnotations;

namespace dragon.Models
{
    public class Cat
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string CatName { get; set; }

        public List<Dish> Dishes { get; set; }
    }
}
