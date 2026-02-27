using FirstERP.Application.DTOs;

namespace FirstERP.Application.Interfaces;

public interface IProductService
{
    Task<IReadOnlyList<ProductDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(ProductDto productDto, CancellationToken cancellationToken = default);
}
