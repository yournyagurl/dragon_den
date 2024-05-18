using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dragon.Models
{
    public class Basket
    {
        [Key]
        public int BasketId { get; set; }
    }
}
