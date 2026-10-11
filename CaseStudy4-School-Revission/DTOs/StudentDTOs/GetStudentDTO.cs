using System.ComponentModel.DataAnnotations;

namespace CaseStudy4_School_Revission.DTOs.StudentDTOs
{
    public class GetStudentDTO
    {
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}
