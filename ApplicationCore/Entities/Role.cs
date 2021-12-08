using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(24)]
        [Required]
        public string Name { get; set; }

        public List<UserRole> UsersOfRole { get; set; }
    }
}
