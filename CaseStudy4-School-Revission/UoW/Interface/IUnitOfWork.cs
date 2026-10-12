using CaseStudy4_School_Revission.Models;
using CaseStudy4_School_Revission.Repos.Interfaces;

namespace CaseStudy4_School_Revission.UoW.Interface
{
    public interface IUnitOfWork
    {
        IStudentRepo Students { get; }
        IGenericRepo<StudentProfile> StudentProfiles { get; }
        IGenericRepo<Teacher> Teachers { get; }
        ICourseRepo Courses { get; }
        IEnrollmentRepo Enrollments { get; }
        IReportRepo Reports { get; }
        IAuthRepo authRepo { get; }
        Task<int> SaveAsync();
    }
}
