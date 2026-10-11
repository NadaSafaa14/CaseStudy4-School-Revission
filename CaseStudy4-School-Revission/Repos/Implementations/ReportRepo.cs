using CaseStudy4_School_Revission.Data;
using CaseStudy4_School_Revission.DTOs.CoursesDTOs;
using CaseStudy4_School_Revission.DTOs.EnrollmentDTOs;
using CaseStudy4_School_Revission.DTOs.StudentDTOs;
using CaseStudy4_School_Revission.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4_School_Revission.Repos.Implementations
{
    public class ReportRepo : IReportRepo
    {
        protected readonly AppDbContext _context;

        public ReportRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CourseStatisticsDto>> GetCourseStatisticsAsync()
        {
            return await _context.Courses
                .Select(c => new CourseStatisticsDto
                {
                    CourseTitle = c.Title,

                    TeacherName = c.Teacher!.FullName,

                    StudentCount = c.Enrollments.Count()
                })
                .ToListAsync();
        }



        public async Task<List<AverageGradeDto>> GetAverageGradesAsync()
        {
            return await _context.Courses
                .Select(c => new AverageGradeDto
                {
                    CourseTitle = c.Title,

                    AverageGrade = c.Enrollments
                        .Where(e => e.Grade.HasValue)
                        .Average(e => e.Grade) ?? 0
                })
                .ToListAsync();
        }

        public async Task<List<TopStudentDto>> GetTopStudentsAsync()
        {
            return await _context.Students
                .Select(s => new TopStudentDto
                {
                    StudentName = s.FullName,

                    AverageGrade = s.Enrollments
                        .Where(e => e.Grade.HasValue)
                        .Average(e => e.Grade) ?? 0
                })
                .OrderByDescending(s => s.AverageGrade)
                .Take(10)
                .ToListAsync();
        }
    }
}
