using Microsoft.AspNetCore.Mvc;
using System.Data;
using gerenciamento_de_produto.Service;
using gerenciamento_de_produto.Dto.Request;
using Swashbuckle.AspNetCore.Annotations;

namespace gerenciamento_de_produto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IDbConnection _connection;

        public ProductController(IProductService productService, IDbConnection connection)
        {
            _productService = productService;
            _connection = connection;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                return Ok(products);

            }
            catch (System.Exception e)
            {
                return NotFound(new { message = e.Message });
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _productService.GetById(id);
                return Ok(product);
            }
            catch (System.Exception e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequest productRequest)
        {
            try
            {
                var newProduct = await _productService.CreateProduct(productRequest);
                return Ok(newProduct);
            }
            catch (System.Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequest productRequest)
        {
            if (productRequest == null)
            {
                return BadRequest();
            }
            try
            {
                var product = await _productService.UpdateProduct(id, productRequest);
                return Ok(product);
            }
            catch (System.Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProduct(id);
                return NoContent();
            }
            catch (System.Exception e)
            {
                return NotFound(new { message = e.Message });
            }
        }
    }
}
