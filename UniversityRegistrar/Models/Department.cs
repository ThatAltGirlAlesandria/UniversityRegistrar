using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
    public class Department
    {
        public int DepartmentId {get; set;}
        [Column(TypeName = "varchar(255)")]
        public string DepartmentName {get; set;}
        //public List<CourseDepartment> JoinCourseDept {get; }
    }
}