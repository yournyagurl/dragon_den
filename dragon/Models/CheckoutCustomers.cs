using System.ComponentModel.DataAnnotations;

namespace dragon.Models
{
    public class CheckoutCustomers
    {
        [Key]
        [StringLength(50)]
        public string Email { get; set; }

        public string Name { get; set; }

        public int BasketId { get; set; }
    }
}
