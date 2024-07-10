using gerenciamento_de_produto.Dto.Request;
using gerenciamento_de_produto.Dto.Response;
using gerenciamento_de_produto.Exception;
using gerenciamento_de_produto.Model;
using gerenciamento_de_produto.Repository;

namespace gerenciamento_de_produto.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductResponse>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            if (!products.Any())
            {
                throw new ProductNotFoundException();
            }
            return products.Select(p => MapToProductResponse(p));
        }

        public async Task<ProductResponse> GetById(int id)
        {
            var product = await _productRepository.GetById(id) ?? throw new ProductNotFoundException();
            return MapToProductResponse(product);
        }

        public async Task<ProductResponse> CreateProduct(ProductRequest productRequest)
        {
            if (String.IsNullOrEmpty(productRequest.Name))
            {
                throw new ProductMissingFieldException("O campo Nome é obrigatório");
            }
            if (productRequest.Price == null)
            {
                throw new ProductMissingFieldException("O campo Preço é obrigatório");
            }

            var newProduct = new Product
            {
                Name = productRequest.Name,
                Price = (decimal)productRequest.Price
            };

            var createdProduct = await _productRepository.CreateProduct(newProduct);
            return MapToProductResponse(createdProduct);
        }

        public async Task<ProductResponse> UpdateProduct(int id, ProductRequest productRequest)
        {
            var product = await _productRepository.GetById(id) ?? throw new ProductNotFoundException();
            if (!String.IsNullOrEmpty(productRequest.Name))
            {
                product.Name = productRequest.Name;
            }

            if (productRequest.Price != null)
            {
                product.Price = (decimal)productRequest.Price;
            }
            await _productRepository.UpdateProduct(product);
            return MapToProductResponse(product);
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _productRepository.GetById(id) ?? throw new ProductNotFoundException();
            if (product == null)
            {
                throw new ProductNotFoundException();
            }
            await _productRepository.DeleteProduct(product);
        }

        private static ProductResponse MapToProductResponse(Product product)
        {
            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}

