using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI_Application.Models
{
    public partial class Department
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptUniqueId { get; set; }
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
    }

    public partial class Employee
    {
        [Key]
        public int EmpUniqueId { get; set; }
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public int Salary { get; set; }
        public string Designation { get; set; }
        //[ForeignKey("DeptUniqueId")]
        public int DeptUniqueId { get; set; }

    }

    public class DeptEmp
    {
        public Department Dept;
        public Employee Emp;
    }
}