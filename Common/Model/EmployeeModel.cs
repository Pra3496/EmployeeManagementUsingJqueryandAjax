using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class EmployeeModel
    {
        public long UserId { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Department { get; set; }

        public double Salary { get; set; }

        public DateTime StartDate { get; set; }

        public string Notes { get; set; }
    }
}
