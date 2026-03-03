namespace FirstERP.Web.ViewModels;

public class DashboardViewModel
{
    public int TotalProducts { get; set; }
    public int TotalStockQuantity { get; set; }
    public decimal InventoryValue { get; set; }
    public decimal EstimatedMonthlySales { get; set; }
    public IReadOnlyList<TopProductViewModel> TopProducts { get; set; } = Array.Empty<TopProductViewModel>();
}

public class TopProductViewModel
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
