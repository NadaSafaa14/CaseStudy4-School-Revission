using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4_School_Revission.Models
{
    [Index(nameof(Email),IsUnique = true)]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required , MinLength(3) , MaxLength(100)]
        public string FullName { get; set; }

        [Required , EmailAddress]
        public string Email { get; set; }

        [Required , Phone]
        public string Phone {  get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Gender { get; set; }

        public StudentProfile StudentProfile { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
