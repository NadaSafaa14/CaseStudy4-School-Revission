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

            await _unitOfWork.SaveAsync();

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

            await _unitOfWork.SaveAsync();

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

            await _unitOfWork.SaveAsync();

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

        [HttpGet("filter")]
        public async Task<IActionResult> Filter(int? teacherId, int? creditHours)
        {
            var courses =
                await _unitOfWork.Courses.FilterCoursesAsync(
                    teacherId,
                    creditHours);

            var result = courses.Select(c => new GetCourseDTO
            {
                Id = c.Id,
                Title = c.Title,
                CreditHours = c.CreditHours,
                TeacherId = c.TeacherId
            });

            return Ok(result);
        }

        [HttpGet("{id}/has-students")]
        public async Task<IActionResult> HasStudents(int id)
        {
            var course = await _unitOfWork.Courses.GetById(id);

            if (course == null)
                return NotFound("Course not found");

            bool result =
                await _unitOfWork.Courses.HasStudentsAsync(id);

            return Ok(result);
        }
    }
}
