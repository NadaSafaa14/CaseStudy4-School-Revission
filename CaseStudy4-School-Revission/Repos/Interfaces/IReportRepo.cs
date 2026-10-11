using CaseStudy4_School_Revission.DTOs.CoursesDTOs;
using CaseStudy4_School_Revission.DTOs.EnrollmentDTOs;
using CaseStudy4_School_Revission.DTOs.StudentDTOs;

namespace CaseStudy4_School_Revission.Repos.Interfaces
{
    public interface IReportRepo
    {
        Task<List<CourseStatisticsDto>> GetCourseStatisticsAsync();

        Task<List<AverageGradeDto>> GetAverageGradesAsync();

        Task<List<TopStudentDto>> GetTopStudentsAsync();
    }
}
