using CaseStudy4_School_Revission.Data;
using CaseStudy4_School_Revission.Models;
using CaseStudy4_School_Revission.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4_School_Revission.Repos.Implementations
{
    public class EnrollmentRepo : GenericRepo<Enrollment>, IEnrollmentRepo
    {
        protected readonly AppDbContext _context;
        public EnrollmentRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Enrollment>> GetByCourseAsync(int courseId)
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => e.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<List<Enrollment>> GetByStudentAsync(int studentId)
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => e.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<List<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToListAsync();
        }

        public async Task<bool> IsStudentEnrolledAsync(int studentId, int courseId)
        {
            return await _context.Enrollments
                .AnyAsync(e =>
                    e.StudentId == studentId &&
                    e.CourseId == courseId);
        }
    }
}
