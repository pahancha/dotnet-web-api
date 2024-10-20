using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{

    // this is a join table
    [Table("Portfolios")]
    public class Portfolio
    {
        public string AppUserId { get; set; }
        public int StockId { get; set; }

        // navigation properties
        public AppUser AppUser { get; set; }
        public Stock Stock { get; set; }
    }
}
