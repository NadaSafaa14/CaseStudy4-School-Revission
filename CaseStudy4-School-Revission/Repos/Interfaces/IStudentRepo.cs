using CaseStudy4_School_Revission.DTOs.StudentDTOs;
using CaseStudy4_School_Revission.Models;
using CaseStudy4_School_Revission.Repos.Implementations;

namespace CaseStudy4_School_Revission.Repos.Interfaces
{
    public interface IStudentRepo : IGenericRepo<Student>
    {
        public Task<List<Student>> SearchStudentsByName(string? name);
        public Task<List<Student>> SearchStudentsByGender(string? gender);
        public Task<List<Student>> Paging(int pageNumber , int pageSize);
    }
}
