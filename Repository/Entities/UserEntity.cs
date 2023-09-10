using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repository.Entities
{
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public long UserId { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Department { get; set; }

        public double Salary { get; set; }

        public DateTime StartDate { get; set; }

        public string Notes { get; set; }


    }
}
