
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();

        Task<Student?> GetStudentById(long id);

        Task<List<Student>> CreateStudent(Student student);

        Task<Student?> UpdateStudent(long id, Student updatedStudent);

        Task<bool> DeleteStudent(long id);
    }
}
