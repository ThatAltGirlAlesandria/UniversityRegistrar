using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistrar.Models
{
    public class Student
    {
        public int StudentId {get; set;}
        [Display(Name="Full Name: ")]
        [Column(TypeName = "varchar(255)")]
        public string StudentName {get; set;}
        [Display(Name="Enrollment Date: ")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage="Date only")]
        public DateTime EnrollmentDate {get; set;}
        public List<StudentCourse> JoinStudentCourse {get;}
    }
}