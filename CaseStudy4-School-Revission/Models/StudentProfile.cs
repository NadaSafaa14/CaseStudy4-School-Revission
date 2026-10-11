using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CaseStudy4_School_Revission.Models
{
    public class StudentProfile
    {
        [Key]
        public int Id { get; set; }

        [Required , MaxLength(200)]
        public string Address { get; set; }

        [Required , Phone]
        public string ParentPhone { get; set; }

        [Required , Phone]
        public string EmergencyContact { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
