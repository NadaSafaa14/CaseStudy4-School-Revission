using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CaseStudy4_School_Revission.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required , MinLength(3) , MaxLength(100)]
        public string FullName { get; set; }

        [Required , EmailAddress]
        public string Email { get; set; }

        [Required , Phone]
        public string Phone { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
