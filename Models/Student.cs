
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    [Table("students")]
    public class Student : BaseModel
    {
        [PrimaryKey("id", false)]
        public long Id { get; set; }

        [Column("first_name")]
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; } = string.Empty;

        [Column("last_name")]
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;

        [Column("enrollment_number")]
        [Required(ErrorMessage = "Enrollment number is required.")]
        [StringLength(20)]
        public string EnrollmentNumber { get; set; } = string.Empty;

        [Column("email")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [Column("career")]
        [Required(ErrorMessage = "Career is required.")]
        [StringLength(100)]
        public string Career { get; set; } = string.Empty;
    }
}
