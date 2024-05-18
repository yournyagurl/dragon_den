using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace dragon.Models
{
    public class AppUser : IdentityUser
    {
        [PersonalData]
        [Required]
        public string FirstName { get; set; }

        [PersonalData]
        [Required]
        public string LastName { get; set; }

        [PersonalData]
        public string Address { get; set; }

        [PersonalData]
        public string City { get; set; }

        [PersonalData]
        [DataType(DataType.Date)]
        public DateTime UserCreationDate { get; set; } = DateTime.Now;
    }
}
