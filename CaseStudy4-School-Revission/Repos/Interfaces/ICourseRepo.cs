using CaseStudy4_School_Revission.Models;

namespace CaseStudy4_School_Revission.Repos.Interfaces
{
    public interface ICourseRepo : IGenericRepo<Course>
    {
        public Task<List<Course>> SearchCourseByTitle(string? title);

    }
}
