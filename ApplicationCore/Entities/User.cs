using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(7)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [MaxLength(1024)]
        public string HashedPassword { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Salt { get; set; }

        [Required]
        [MaxLength(16)]
        public string PhoneNumber { get; set; }

        [Required]
        public bool TwoFactorEnabled { get; set; }

        [Required]
        [MaxLength(7)]
        public DateTime? LockoutEndDate { get; set; }

        [Required]
        [MaxLength(7)]
        public DateTime? LastLoginDateTime { get; set; }

        [Required]
        public bool IsLocked { get; set; }

        [Required]
        public int AccessFailedCount { get; set; }

        public List<Favorite> Favorites { get; set; }
        public List<Purchase> Purchases { get; set; }
    }
}
