using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy4_School_Revission.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required , MinLength(3) , MaxLength(100)]
        public string Title { get; set; }

        [Required , Range(1 , 6)]
        public int CreditHours { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
