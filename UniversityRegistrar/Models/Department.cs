using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityRegistrar.Models
{
    public class Department
    {
        public int DepartmentId {get; set;}
        [Column(TypeName = "varchar(255)")]
        public string DepartmentName {get; set;}
    }
}