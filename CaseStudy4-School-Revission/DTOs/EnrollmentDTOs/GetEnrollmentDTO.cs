using CaseStudy4_School_Revission.Models;
using System.ComponentModel.DataAnnotations;

namespace CaseStudy4_School_Revission.DTOs.EnrollmentDTOs
{
    public class GetEnrollmentDTO
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [Range(0, 100)]
        public decimal? Grade { get; set; }
    }
}
