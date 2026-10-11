using CaseStudy4_School_Revission.Data;
using CaseStudy4_School_Revission.Models;
using CaseStudy4_School_Revission.Repos.Interfaces;

namespace CaseStudy4_School_Revission.Repos.Implementations
{
    public class CourseRepo : GenericRepo<Course>, ICourseRepo
    {
        protected readonly AppDbContext _context;
        public CourseRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Course>> SearchCourseByTitle(string? title)
        {
            var courses = await _context.Courses.Where(s => s.Title.Contains(title)).ToListAsync();

            return courses;
        }
    }
}
