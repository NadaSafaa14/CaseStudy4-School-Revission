using CaseStudy4_School_Revission.DTOs.CoursesDTOs;
using CaseStudy4_School_Revission.DTOs.StudentDTOs;
using CaseStudy4_School_Revission.DTOs.TeacherDTOs;
using CaseStudy4_School_Revission.Models;
using CaseStudy4_School_Revission.UoW.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy4_School_Revission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourcesController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        public CourcesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _unitOfWork.Courses.GetAll();

            if (courses == null || courses.Count == 0)
            {
                return NotFound();
            }

            var dto = new List<GetCourseDTO>();

            foreach (var c in courses)
            {
                dto.Add(new GetCourseDTO
                {
                    CreditHours = c.CreditHours,
                    Id = c.Id,
                    TeacherId = c.TeacherId,
                    Title = c.Title,
                });
            }

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(AddCourseDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var c = new Course
            {
                CreditHours = dto.CreditHours,
                Title = dto.Title,
                TeacherId = dto.TeacherId,
            };

            _unitOfWork.Courses.Add(c);

            _unitOfWork.SaveAsync();

            return Created();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var c = await _unitOfWork.Courses.GetById(id);

            if (c == null)
            {
                return NotFound();
            }

            var dto = new GetCourseDTO
            {
                CreditHours = c.CreditHours,
                Id = c.Id,
                TeacherId = c.TeacherId,
                Title = c.Title,
            };

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, AddCourseDTO dto)
        {
            var c = await _unitOfWork.Courses.GetById(id);

            if (c == null)
            {
                return NotFound();
            }

            c.Title = dto.Title;
            c.TeacherId = dto.TeacherId;
            c.CreditHours = dto.CreditHours;

            _unitOfWork.Courses.Update(c);

            _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var c = await _unitOfWork.Courses.GetById(id);

            if (c == null)
            {
                return NotFound();
            }

            _unitOfWork.Courses.Delete(c);

            _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpGet("search-by-title")]
        public async Task<IActionResult> SearcBytitle(string title)
        {
            var courses = await _unitOfWork.Courses.SearchCourseByTitle(title);

            if (courses == null || courses.Count == 0)
            {
                return NotFound();
            }

            var dto = new List<GetCourseDTO>();

            foreach (var c in courses)
            {
                dto.Add(new GetCourseDTO
                {
                    CreditHours = c.CreditHours,
                    Id = c.Id,
                    TeacherId = c.TeacherId,
                    Title = c.Title,
                });
            }

            return Ok(dto);
        }


    }
}
