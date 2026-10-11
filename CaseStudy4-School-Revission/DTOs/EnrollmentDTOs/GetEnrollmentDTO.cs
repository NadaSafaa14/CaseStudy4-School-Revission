using CaseStudy4_School_Revission.Models;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy4_School_Revission.DTOs.EnrollmentDTOs
{
    public class GetEnrollmentDTO
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        [Required]
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [Range(0, 100)]
        public decimal? Grade { get; set; }
    }
}
