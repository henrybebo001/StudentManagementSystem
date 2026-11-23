
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly Supabase.Client _supabase;

        public StudentsController(Supabase.Client supabase)
        {
            _supabase = supabase;
        }

        // GET: api/students
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var response = await _supabase
                .From<Student>()
                .Get();

            return Ok(response.Models);
        }

        // GET: api/students/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(long id)
        {
            var response = await _supabase
                .From<Student>()
                .Where(s => s.Id == id)
                .Get();

            var student = response.Models.FirstOrDefault();

            if (student == null)
                return NotFound("Student not found.");

            return Ok(student);
        }

        // POST: api/students
        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            student.Id = 0;

            var response = await _supabase
                .From<Student>()
                .Insert(student);

            return Ok(response.Models);
        }

        // PUT: api/students/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(
            long id, Student updatedStudent)
        {
            var response = await _supabase
                .From<Student>()
                .Where(s => s.Id == id)
                .Get();

            var student = response.Models.FirstOrDefault();

            if (student == null)
                return NotFound("Student not found.");

            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            student.EnrollmentNumber = updatedStudent.EnrollmentNumber;
            student.Email = updatedStudent.Email;
            student.Career = updatedStudent.Career;

            await student.Update<Student>();

            return Ok(student);
        }

        // DELETE: api/students/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(long id)
        {
            var response = await _supabase
                .From<Student>()
                .Where(s => s.Id == id)
                .Get();

            var student = response.Models.FirstOrDefault();

            if (student == null)
                return NotFound("Student not found.");

            await student.Delete<Student>();

            return Ok("Student deleted successfully.");
        }
    }
}

