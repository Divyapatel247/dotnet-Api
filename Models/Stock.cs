using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Stocks")]
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = "";
        public string CompanyName { get; set; } = "";

        [Column(TypeName = "REAL")]  // ✅ Use "REAL" for SQLite compatibility
        public double Purchase { get; set; }

        [Column(TypeName = "REAL")]  // ✅ Use "REAL" for SQLite compatibility
        public double Lastdev { get; set; }

        public string Industry { get; set; } = "";
        public long Marketcap { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();

    } 
}
