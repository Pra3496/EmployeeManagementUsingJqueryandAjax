using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Repository.Entities
{
    public class LoginEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LoginId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        [ForeignKey("UsersTable")]
        public long UserId { get; set; }
        [JsonIgnore]
        public virtual UserEntity User { get; set; }
    }
}
