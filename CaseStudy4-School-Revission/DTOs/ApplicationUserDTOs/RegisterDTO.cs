using System.ComponentModel.DataAnnotations;

namespace CaseStudy4_School_Revission.DTOs.ApplicationUserDTOs
{
    public class RegisterDTO
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        public string Role { get; set; } = "Member";
    }
}
