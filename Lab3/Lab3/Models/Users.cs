using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string Address { get; set; }
    }
}
