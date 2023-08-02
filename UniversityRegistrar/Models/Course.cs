using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
    [Index(nameof(CourseName), IsUnique = true)]
    public class Course
    {
        public int CourseId { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string CourseName { get; set; }
        public List<StudentCourse> JoinStudentCourse {get;}
        //public List<CourseDepartment> JoinCourseDept {get; }
    }
}