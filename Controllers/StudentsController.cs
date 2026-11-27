
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(long id)
        {
            var student = await _studentService.GetStudentById(id);

            if (student == null)
                return NotFound("Student not found.");

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            var createdStudent = await _studentService.CreateStudent(student);
            return Ok(createdStudent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(
            long id, Student updatedStudent)
        {
            var student = await _studentService.UpdateStudent(
                id, updatedStudent);

            if (student == null)
                return NotFound("Student not found.");

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(long id)
        {
            var deleted = await _studentService.DeleteStudent(id);

            if (!deleted)
                return NotFound("Student not found.");

            return Ok("Student deleted successfully.");
        }
    }
}
