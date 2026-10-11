using CaseStudy4_School_Revission.Data;
using CaseStudy4_School_Revission.Models;
using CaseStudy4_School_Revission.Repos.Interfaces;
using CaseStudy4_School_Revission.UoW.Interface;

namespace CaseStudy4_School_Revission.UoW.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _context;
        public IStudentRepo Students { get; }
        public IGenericRepo<StudentProfile> StudentProfiles { get; }

        public IGenericRepo<Teacher> Teachers {  get; }

        public ICourseRepo Courses {  get; }

        public IEnrollmentRepo Enrollments { get; }

        public IReportRepo Reports { get; }

        public UnitOfWork(AppDbContext context , IStudentRepo students, IGenericRepo<StudentProfile> studentProfiles, IGenericRepo<Teacher> teachers, ICourseRepo courses , IEnrollmentRepo enrollments , IReportRepo reports)
        {
            _context = context;
            Students = students;
            StudentProfiles = studentProfiles;
            Teachers = teachers;
            Courses = courses;
            Enrollments = enrollments;
            Reports = reports;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
