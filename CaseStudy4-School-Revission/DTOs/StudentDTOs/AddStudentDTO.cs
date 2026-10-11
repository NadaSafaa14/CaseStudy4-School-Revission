using System.ComponentModel.DataAnnotations;

namespace CaseStudy4_School_Revission.DTOs.StudentDTOs
{
    public class AddStudentDTO
    {
        [Required , MinLength(3) , MaxLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required, MaxLength(200)]
        public string Address { get; set; }

        [Required, Phone]
        public string ParentPhone { get; set; }

        [Required, Phone]
        public string EmergencyContact { get; set; }
    }
}
