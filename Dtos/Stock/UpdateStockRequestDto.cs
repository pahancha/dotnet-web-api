using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "The max length of the symbol can not be over 10 characters.")]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MaxLength(20, ErrorMessage = "The max length of the company name can not be over 20 characters.")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(1, 10000000)]
        public decimal Purchase { get; set; }

        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Industy length can not be over 10 characters.")]
        public string Industry { get; set; } = string.Empty;

        [Range(1, 5000000000)]
        public long MarketCap { get; set; }
    }
}
