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
            var enrollments = await _unitOfWork.Enrollments.GetAll();

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

            var e = new Enrollment
            {
                CourseId =dto.CourseId,
                EnrollmentDate = dto.EnrollmentDate,
                Grade = dto.Grade,
                StudentId=dto.StudentId,
            };

            _unitOfWork.Enrollments.Add(e);

            _unitOfWork.SaveAsync();

            return Created();
        }

    }
}
