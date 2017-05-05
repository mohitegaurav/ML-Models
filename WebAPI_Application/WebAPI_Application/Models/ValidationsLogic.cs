using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI_Application.Models
{
    [MetadataType(typeof(DepartmentMetadata))]
    public partial class Department
    {
        private class DepartmentMetadata
        {
            [Required(ErrorMessage = "DeptNo is Must")]
            [NumericValidationArribute (ErrorMessage ="Value cannot be negative")]
            public int DeptNo { get; set; }
            [Required(ErrorMessage = "DeptName is Must")]
            public string DeptName { get; set; }
            [Required(ErrorMessage = "Location is Must")]
            public string Location { get; set; }
            [Required(ErrorMessage = "Capacity is Must")]
            public int Capacity { get; set; }
        }
    }

    public class NumericValidationArribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int val = (int)value;
            if (val < 0)
            {
                return false;
            }
            else {
                return true;
            }
        }
    }

    public partial class Employee : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EmpName.Length < 0 || string.IsNullOrEmpty(EmpName))
            {
                yield return new ValidationResult("Employee Name must be entered.");
            }
            if (Salary <= 0 || Salary > 100000)
            {
                yield return new ValidationResult("Please enter salary in less then 1L.");
            }
        }
    }
}