using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IStudentService _studentService;

        public IndexModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public List<Student> Students { get; set; } = new();

        public int TotalStudents { get; set; }

        public int TotalCareers { get; set; }

        public async Task OnGetAsync()
        {
            Students = await _studentService.GetAllStudents();

            TotalStudents = Students.Count;

            TotalCareers = Students
                .Select(s => s.Career)
                .Distinct()
                .Count();
        }
    }
}