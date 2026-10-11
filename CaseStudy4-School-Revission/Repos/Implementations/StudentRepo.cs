using CaseStudy4_School_Revission.Data;
using CaseStudy4_School_Revission.DTOs.StudentDTOs;
using CaseStudy4_School_Revission.Models;
using CaseStudy4_School_Revission.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4_School_Revission.Repos.Implementations
{
    public class StudentRepo : GenericRepo<Student>, IStudentRepo
    {
        protected readonly AppDbContext _context;
        public StudentRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Student>> Paging(int pageNumber, int pageSize)
        {
            var students = await _context.Students.Skip((pageSize - 1) * pageNumber).Take(pageSize).ToListAsync();

            return students;
        }

        public async Task<List<Student>> SearchStudentsByGender(string? gender)
        {
            var students = await _context.Students.Where(s => s.Gender.Contains(gender)).ToListAsync();

            return students;
        }

        public async Task<List<Student>> SearchStudentsByName(string? name)
        {
            var students = await _context.Students.Where(s => s.FullName.Contains(name)).ToListAsync();

            return students;
        }
    }
}
