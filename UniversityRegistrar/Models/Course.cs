using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace UniversityRegistrar.Models
{
    [Index(nameof(CourseName), IsUnique = true)]
    public class Course
    {
        public int CourseId { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string CourseName { get; set; }
    }
}