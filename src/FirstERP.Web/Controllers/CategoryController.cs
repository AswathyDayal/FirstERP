using FirstERP.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstERP.Web.Controllers;

public class CategoryController : Controller
{
    private const int DefaultPageSize = 5;

    private static readonly List<CategoryListItemViewModel> Categories =
    [
        new() { Id = 1, Name = "Electronics", Description = "Devices and accessories" },
        new() { Id = 2, Name = "Groceries", Description = "Daily essentials" },
        new() { Id = 3, Name = "Stationery", Description = "Office and school supplies" },
        new() { Id = 4, Name = "Furniture", Description = "Home and office furniture" },
        new() { Id = 5, Name = "Clothing", Description = "Apparel and accessories" },
        new() { Id = 6, Name = "Sports", Description = "Sports and fitness items" },
        new() { Id = 7, Name = "Beauty", Description = "Beauty and personal care" }
    ];

    [HttpGet]
    public IActionResult Index(int page = 1)
    {
        if (page < 1)
        {
            page = 1;
        }

        var totalCount = Categories.Count;
        var items = Categories
            .OrderBy(c => c.Name)
            .Skip((page - 1) * DefaultPageSize)
            .Take(DefaultPageSize)
            .ToList();

        var model = new PagedCategoriesViewModel
        {
            Items = items,
            CurrentPage = page,
            PageSize = DefaultPageSize,
            TotalCount = totalCount
        };

        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CategoryViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CategoryViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var nextId = Categories.Count == 0 ? 1 : Categories.Max(c => c.Id) + 1;
        Categories.Add(new CategoryListItemViewModel
        {
            Id = nextId,
            Name = model.Name,
            Description = model.Description
        });

        TempData["SuccessMessage"] = "Category created successfully.";
        return RedirectToAction(nameof(Index));
    }
}
