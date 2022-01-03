using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class MoviePurchaseDetailsModel
    {
        public int UserId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? PurchaseAmount { get; set; }
        public Guid PurchaseNumber { get; set; }
        public int MovieId { get; set; }
    }
}
