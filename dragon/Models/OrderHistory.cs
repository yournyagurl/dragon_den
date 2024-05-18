using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dragon.Models
{
    public class OrderHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderNo { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfOrder { get; set; }

        // Constructor to set the current date and time
        public OrderHistory()
        {
            DateOfOrder = DateTime.Now;
        }
    }


}