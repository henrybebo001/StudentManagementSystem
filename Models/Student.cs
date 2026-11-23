
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace StudentManagementSystem.Models
{
    [Table("students")]
    public class Student : BaseModel
    {
        [PrimaryKey("id", false)]
        public long Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; } = string.Empty;

        [Column("last_name")]
        public string LastName { get; set; } = string.Empty;

        [Column("enrollment_number")]
        public string EnrollmentNumber { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("career")]
        public string Career { get; set; } = string.Empty;
    }
}
