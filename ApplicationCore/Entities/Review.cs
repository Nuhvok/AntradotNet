using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Review")]
    public class Review
    {
        public int MovieId { get; set; }

        public int UserId { get; set; }

        public decimal? Rating { get; set; }

        [Required]
        public string? ReviewText { get; set; }

        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
