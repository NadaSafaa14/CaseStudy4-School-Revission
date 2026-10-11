using CaseStudy4_School_Revission.DTOs.CoursesDTOs;
using CaseStudy4_School_Revission.DTOs.EnrollmentDTOs;
using CaseStudy4_School_Revission.Models;
using CaseStudy4_School_Revission.UoW.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy4_School_Revission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        public EnrollmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var enrollments = await _unitOfWork.Enrollments.GetAllEnrollmentsAsync();

            if (enrollments == null || enrollments.Count == 0)
            {
                return NotFound();
            }

            var dto = new List<GetEnrollmentDTO>();

            foreach (var e in enrollments)
            {
                dto.Add(new GetEnrollmentDTO
                {
                    CourseId = e.CourseId,
                    EnrollmentDate = e.EnrollmentDate,
                    Grade = e.Grade,
                    Id = e.Id,
                    StudentId = e.StudentId,
                    StudentName = e.Student?.FullName ?? "Unknown",
                    CourseTitle = e.Course?.Title ?? "Unknown",
                });
            }

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddEnrollment(AddEnrollmentDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var student = await _unitOfWork.Students
                .GetById(dto.StudentId);

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            var course = await _unitOfWork.Courses
                .GetById(dto.CourseId);

            if (course == null)
            {
                return NotFound("Course not found.");
            }

            bool alreadyEnrolled =
                await _unitOfWork.Enrollments
                    .IsStudentEnrolledAsync(
                        dto.StudentId,
                        dto.CourseId);

            if (alreadyEnrolled)
            {
                return BadRequest(
                    "Student is already enrolled in this course.");
            }

            var e = new Enrollment
            {
                CourseId = dto.CourseId,
                EnrollmentDate = dto.EnrollmentDate,
                Grade = dto.Grade,
                StudentId = dto.StudentId,
            };

            _unitOfWork.Enrollments.Add(e);

            await _unitOfWork.SaveAsync();

            return Created();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var enrollment =
                await _unitOfWork.Enrollments.GetById(id);

            if (enrollment == null)
            { 
                return NotFound("Enrollment not found.");
            }

            _unitOfWork.Enrollments.Delete(enrollment);

            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpGet("course/{id}")]
        public async Task<IActionResult> GetByCourse(int id)
        {
            var course =
                await _unitOfWork.Courses.GetById(id);

            if (course == null)
            {
                return NotFound("Course not found.");
            }

            var enrollments =
                await _unitOfWork.Enrollments.GetByCourseAsync(id);

            var result = enrollments.Select(e => new GetEnrollmentDTO
            {
                Id = e.Id,
                CourseId = e.CourseId,
                StudentId = e.StudentId,
                StudentName = e.Student?.FullName ?? "Unknown",
                CourseTitle = e.Course?.Title ?? "Unknown",
                EnrollmentDate = e.EnrollmentDate,
                Grade = e.Grade
            });

            return Ok(result);
        }

        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetByStudent(int id)
        {
            var s =
                await _unitOfWork.Students.GetById(id);

            if (s == null)
            {
                return NotFound("Student not found.");
            }

            var enrollments =
                await _unitOfWork.Enrollments.GetByStudentAsync(id);

            var result = enrollments.Select(e => new GetEnrollmentDTO
            {
                Id = e.Id,
                CourseId = e.CourseId,
                StudentId = e.StudentId,
                StudentName = e.Student?.FullName ?? "Unknown",
                CourseTitle = e.Course?.Title ?? "Unknown",
                EnrollmentDate = e.EnrollmentDate,
                Grade = e.Grade
            });

            return Ok(result);
        }

    }
}
