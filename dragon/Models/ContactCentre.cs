using System.ComponentModel.DataAnnotations;

namespace dragon.Models
{
    public class ContactCentre
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }


        [Required]
        public string Message { get; set; }
    }
}
