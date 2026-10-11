using CaseStudy4_School_Revission.DTOs.StudentDTOs;
using CaseStudy4_School_Revission.Models;
using CaseStudy4_School_Revission.UoW.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy4_School_Revission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentDTO dto)
        {
            if(dto == null)
            {
                return BadRequest("data is null");
            }

            var student = new Student
            {
                FullName = dto.FullName,
                BirthDate = dto.BirthDate,
                Email = dto.Email,
                Gender = dto.Gender,
                Phone = dto.Phone,
            };

            var studentprofile = new StudentProfile
            {
                Address = dto.Address,
                EmergencyContact = dto.EmergencyContact,
                ParentPhone = dto.ParentPhone,
                StudentId = student.Id,
            };

            _unitOfWork.Students.Add(student);

            _unitOfWork.StudentProfiles.Add(studentprofile);

            _unitOfWork.SaveAsync();

            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _unitOfWork.Students.GetAll();

            if(students == null)
            {
                return NotFound();
            }

            var dto = new List<GetStudentDTO>();

            foreach (var student in students)
            {
                dto.Add(new GetStudentDTO
                {
                    FullName = student.FullName,
                    BirthDate = student.BirthDate,
                    Email = student.Email,
                    Gender = student.Gender,
                    Phone = student.Phone,
                    Id = student.Id,
                });
            }

                return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _unitOfWork.Students.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            var dto = new GetStudentDTO
            {
                FullName = student.FullName,
                BirthDate = student.BirthDate,
                Email = student.Email,
                Gender = student.Gender,
                Phone = student.Phone,
                Id = student.Id,
            };

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id , UpdateStudentDTO dto)
        {
            var student = await _unitOfWork.Students.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            //var studentprofile = await _unitOfWork.StudentProfiles.GetById(student.StudentProfile.Id);

            //if (studentprofile == null)
            //{  
            //    return NotFound(); 
            //}

            student.BirthDate = dto.BirthDate;
            student.Email = dto.Email;
            student.Gender = dto.Gender;
            student.Phone = dto.Phone;
            student.FullName = dto.FullName;

            //studentprofile.Address = dto.Address;
            //studentprofile.ParentPhone = dto.ParentPhone;
            //studentprofile.EmergencyContact = dto.EmergencyContact;

            //_unitOfWork.StudentProfiles.Update(studentprofile);

            _unitOfWork.Students.Update(student);

            _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _unitOfWork.Students.GetById(id);

            if ( student == null)
            {
                return NotFound();
            }

            _unitOfWork.Students.Delete(student);

            _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpGet("search-by-name")]
        public async Task<IActionResult> SearcByName(string name)
        {
            var students = await _unitOfWork.Students.SearchStudentsByName(name);

            if(students == null || students.Count == 0)
            {
                return NotFound();
            }

            var dto = new List<GetStudentDTO>();

            foreach (var student in students)
            {
                dto.Add(new GetStudentDTO
                {
                    FullName = student.FullName,
                    BirthDate = student.BirthDate,
                    Email = student.Email,
                    Gender = student.Gender,
                    Phone = student.Phone,
                    Id = student.Id,
                });
            }

            return Ok(dto);
        }

        [HttpGet("search-by-gender")]
        public async Task<IActionResult> SearcByGender(string gender)
        {
            var students = await _unitOfWork.Students.SearchStudentsByGender(gender);

            if (students == null || students.Count == 0)
            {
                return NotFound();
            }

            var dto = new List<GetStudentDTO>();

            foreach (var student in students)
            {
                dto.Add(new GetStudentDTO
                {
                    FullName = student.FullName,
                    BirthDate = student.BirthDate,
                    Email = student.Email,
                    Gender = student.Gender,
                    Phone = student.Phone,
                    Id = student.Id,
                });
            }

            return Ok(dto);
        }

        [HttpGet("Paging")]
        public async Task<IActionResult> Paging(int pagesize , int pagenumber)
        {
            var students = await _unitOfWork.Students.Paging(pagesize, pagenumber);

            if (students == null || students.Count == 0)
            {
                return NotFound();
            }

            var dto = new List<GetStudentDTO>();

            foreach (var student in students)
            {
                dto.Add(new GetStudentDTO
                {
                    FullName = student.FullName,
                    BirthDate = student.BirthDate,
                    Email = student.Email,
                    Gender = student.Gender,
                    Phone = student.Phone,
                    Id = student.Id,
                });
            }

            return Ok(dto);
        }
    }
}
