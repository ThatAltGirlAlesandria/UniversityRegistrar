using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityRegistrar.Models
{
    public class Student
    {
        public int StudentId {get; set;}
        [Column(TypeName = "varchar(255)")]
        public string StudentName {get; set;}
        public DateTime EnrollmentDate {get; set;}
    }
}