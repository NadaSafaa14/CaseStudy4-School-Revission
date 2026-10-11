using CaseStudy4_School_Revission.Models;

namespace CaseStudy4_School_Revission.Repos.Interfaces
{
    public interface IEnrollmentRepo : IGenericRepo<Enrollment>
    {
        public Task<List<Enrollment>> GetByStudentAsync(int studentId);
        public Task<List<Enrollment>> GetByCourseAsync(int courseId);
        public Task<bool> IsStudentEnrolledAsync(int studentId, int courseId);
        public Task<List<Enrollment>> GetAllEnrollmentsAsync();
    }
}
