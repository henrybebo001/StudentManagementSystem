
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly Supabase.Client _supabase;

        public StudentService(Supabase.Client supabase)
        {
            _supabase = supabase;
        }

        // Get all students
        public async Task<List<Student>> GetAllStudents()
        {
            var response = await _supabase
                .From<Student>()
                .Get();

            return response.Models;
        }

        // Get student by ID
        public async Task<Student?> GetStudentById(long id)
        {
            var response = await _supabase
                .From<Student>()
                .Where(s => s.Id == id)
                .Get();

            return response.Models.FirstOrDefault();
        }

        // Create student
        public async Task<List<Student>> CreateStudent(Student student)
        {
            student.Id = 0;

            var response = await _supabase
                .From<Student>()
                .Insert(student);

            return response.Models;
        }

        // Update student
        public async Task<Student?> UpdateStudent(
            long id,
            Student updatedStudent)
        {
            var student = await GetStudentById(id);

            if (student == null)
                return null;

            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            student.EnrollmentNumber = updatedStudent.EnrollmentNumber;
            student.Email = updatedStudent.Email;
            student.Career = updatedStudent.Career;

            await student.Update<Student>();

            return student;
        }

        // Delete student
        public async Task<bool> DeleteStudent(long id)
        {
            var student = await GetStudentById(id);

            if (student == null)
                return false;

            await student.Delete<Student>();

            return true;
        }
    }
}
