using System.ComponentModel.DataAnnotations;

namespace CaseStudy4_School_Revission.DTOs.CoursesDTOs
{
    public class GetCourseDTO
    {
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(100)]
        public string Title { get; set; }

        [Required, Range(1, 6)]
        public int CreditHours { get; set; }

        public int TeacherId { get; set; }
    }
}
