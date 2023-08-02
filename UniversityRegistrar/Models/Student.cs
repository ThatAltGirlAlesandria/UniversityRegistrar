using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
    public class Student
    {
        public int StudentId {get; set;}
        [Column(TypeName = "varchar(255)")]
        public string StudentName {get; set;}
        public DateTime EnrollmentDate {get; set;}
        public List<StudentCourse> JoinStudentCourse {get;}
    }
}