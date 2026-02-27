using System.ComponentModel.DataAnnotations;

namespace FirstERP.Web.ViewModels;

public class ProductViewModel
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, 999999)]
    public decimal Price { get; set; }

    [Range(0, 100000)]
    public int StockQuantity { get; set; }
}
