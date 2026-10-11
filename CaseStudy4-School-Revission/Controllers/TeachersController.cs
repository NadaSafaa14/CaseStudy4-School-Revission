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
    public class TeachersController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        public TeachersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _unitOfWork.Teachers.GetAll();

            if (teachers == null ||  teachers.Count == 0)
            {
                return NotFound();
            }

            var dto = new List<GetTeacherDTO>();

            foreach (var teacher in teachers)
            {
                dto.Add(new GetTeacherDTO
                {
                    FullName = teacher.FullName,
                    Email = teacher.Email,
                    HireDate = teacher.HireDate,
                    Id = teacher.Id,
                    Phone = teacher.Phone,
                });
            }

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher(AddTeacherDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var teacher = new Teacher
            {
                FullName = dto.FullName,
                Email = dto.Email,
                HireDate = dto.HireDate,
                Phone = dto.Phone,
            };

            _unitOfWork.Teachers.Add(teacher);

            _unitOfWork.SaveAsync();

            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var teacher = await _unitOfWork.Teachers.GetById(id);

            if (teacher == null)
            {
                return NotFound();
            }

            var dto = new GetTeacherDTO
            {
                FullName = teacher.FullName,
                Email = teacher.Email,
                HireDate = teacher.HireDate,
                Phone = teacher.Phone,
                Id = id
            };

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, AddTeacherDTO dto)
        {
            var teacher = await _unitOfWork.Teachers.GetById(id);

            if (teacher == null)
            {
                return NotFound();
            }

            teacher.HireDate = dto.HireDate;
            teacher.Phone = dto.Phone;
            teacher.FullName = dto.FullName;
            teacher.Email = dto.Email;

            _unitOfWork.Teachers.Update(teacher);

            _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _unitOfWork.Teachers.GetById(id);

            if (teacher == null)
            {
                return NotFound();
            }

            _unitOfWork.Teachers.Delete(teacher);

            _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
