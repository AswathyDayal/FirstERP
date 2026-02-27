using FirstERP.Application.DTOs;
using FirstERP.Application.Interfaces;
using FirstERP.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstERP.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var products = await _productService.GetAllAsync(cancellationToken);
        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new ProductViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductViewModel model, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _productService.AddAsync(new ProductDto
        {
            Name = model.Name,
            Price = model.Price,
            StockQuantity = model.StockQuantity
        }, cancellationToken);

        TempData["SuccessMessage"] = "Product created successfully.";
        return RedirectToAction(nameof(Index));
    }
}
