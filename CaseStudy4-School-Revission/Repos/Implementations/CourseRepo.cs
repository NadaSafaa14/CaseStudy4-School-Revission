using CaseStudy4_School_Revission.Data;
using CaseStudy4_School_Revission.Models;
using CaseStudy4_School_Revission.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4_School_Revission.Repos.Implementations
{
    public class CourseRepo : GenericRepo<Course>, ICourseRepo
    {
        protected readonly AppDbContext _context;
        public CourseRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Course>> FilterCoursesAsync(int? teacherId, int? creditHours)
        {
            IQueryable<Course> query = _context.Courses.Include(c => c.Teacher);

            if (teacherId.HasValue)
            { 
                query = query.Where(c => c.TeacherId == teacherId); 
            }

            if (creditHours.HasValue)
            {
                query = query.Where(c => c.CreditHours == creditHours);
            }

            return await query.ToListAsync();
        }

        public async Task<List<Course>> SearchCourseByTitle(string? title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return new List<Course>();
            }

            var courses = await _context.Courses.Where(s => s.Title.Contains(title)).ToListAsync();

            return courses;
        }

        public async Task<bool> HasStudentsAsync(int courseId)
        {
            return await _context.Enrollments.AnyAsync(e => e.CourseId == courseId);
        }

    }
}
