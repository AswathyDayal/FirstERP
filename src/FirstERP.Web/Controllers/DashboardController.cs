using FirstERP.Application.Interfaces;
using FirstERP.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstERP.Web.Controllers;

public class DashboardController : Controller
{
    private readonly IProductService _productService;

    public DashboardController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var products = await _productService.GetAllAsync(cancellationToken);

        var topProducts = products
            .OrderByDescending(item => item.Price * item.StockQuantity)
            .Take(5)
            .Select(item => new TopProductViewModel
            {
                Name = item.Name,
                Price = item.Price,
                StockQuantity = item.StockQuantity
            })
            .ToList();

        var viewModel = new DashboardViewModel
        {
            TotalProducts = products.Count,
            TotalStockQuantity = products.Sum(item => item.StockQuantity),
            InventoryValue = products.Sum(item => item.Price * item.StockQuantity),
            EstimatedMonthlySales = products.Sum(item => item.Price * item.StockQuantity) * 0.20m,
            TopProducts = topProducts
        };

        return View(viewModel);
    }
}
