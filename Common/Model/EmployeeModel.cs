using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Model
{
    public class EmployeeModel
    {
        public long UserId { get; set; }

        [Required(ErrorMessage = "{0} should be given")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} should be given")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "{0} should be given")]
        public string Department { get; set; }

        [Required(ErrorMessage = "{0} should be given")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "{0} should be given")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "{0} should be given")]
        public string Notes { get; set; }
    }
}
