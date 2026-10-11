using System.ComponentModel.DataAnnotations;

namespace CaseStudy4_School_Revission.DTOs.TeacherDTOs
{
    public class GetTeacherDTO
    {
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        [Required]
        public DateTime HireDate { get; set; }
    }
}
