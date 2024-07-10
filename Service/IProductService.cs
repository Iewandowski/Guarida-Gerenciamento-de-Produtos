using gerenciamento_de_produto.Dto.Request;
using gerenciamento_de_produto.Dto.Response;

namespace gerenciamento_de_produto.Service
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetAllProducts();
        Task<ProductResponse> GetById(int id);
        Task<ProductResponse> CreateProduct(ProductRequest productRequest);
        Task<ProductResponse> UpdateProduct(int id, ProductRequest productRequest);
        Task DeleteProduct(int id);
    }
}
