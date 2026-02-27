using FirstERP.Application.DTOs;
using FirstERP.Application.Interfaces;
using FirstERP.Domain.Entities;
using FirstERP.Domain.Interfaces;

namespace FirstERP.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var products = await _productRepository.GetAllAsync(cancellationToken);
        return products
            .Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                StockQuantity = x.StockQuantity
            })
            .ToList();
    }

    public async Task AddAsync(ProductDto productDto, CancellationToken cancellationToken = default)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
            StockQuantity = productDto.StockQuantity
        };

        await _productRepository.AddAsync(product, cancellationToken);
    }
}
