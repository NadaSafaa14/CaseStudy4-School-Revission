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
            var students = await _context.Students
                .OrderBy(s => s.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return students;
        }

        public async Task<List<Student>> SearchStudentsByGender(string? gender)
        {
            if (string.IsNullOrWhiteSpace(gender))
            {
                return new List<Student>();
            }

            var students = await _context.Students.Where(s => s.Gender.ToLower() == gender.ToLower()).ToListAsync();

            return students;
        }

        public async Task<List<Student>> SearchStudentsByName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            { 
                return new List<Student>();
            }

            var students = await _context.Students.Where(s => s.FullName.Contains(name)).ToListAsync();

            return students;
        }
    }
}
