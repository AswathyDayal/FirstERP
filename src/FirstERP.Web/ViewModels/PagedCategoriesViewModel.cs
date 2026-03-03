namespace FirstERP.Web.ViewModels;

public class PagedCategoriesViewModel
{
    public IReadOnlyList<CategoryListItemViewModel> Items { get; set; } = [];

    public int CurrentPage { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    public int TotalPages => TotalCount == 0 ? 1 : (int)Math.Ceiling(TotalCount / (double)PageSize);
}
