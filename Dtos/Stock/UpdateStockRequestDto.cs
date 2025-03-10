using System;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Stock;

public class UpdateStockRequestDto
{
    [Required]
        [MaxLength(10, ErrorMessage = "Symbol can't be over 10 characters")]
        public string Symbol { get; set; } = "";

        [Required]
        [MaxLength(10, ErrorMessage = "CompanyName can't be over 10 characters")]
        public string CompanyName { get; set; } = "";

        [Required]
        [Range(1, 1000000000)]
        public double Purchase { get; set; }

        [Required]
        [Range(0.001, 100)]
        public double Lastdev { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Industry can't be over 10 characters")]
        public string Industry { get; set; } = "";
        [Range(1,500000000)]
        public long Marketcap { get; set; }

}
