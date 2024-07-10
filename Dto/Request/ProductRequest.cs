using System.ComponentModel.DataAnnotations;

namespace gerenciamento_de_produto.Dto.Request
{
    public class ProductRequest
    {
        public string? Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O campo Preço deve ser maior que zero.")]
        public decimal? Price { get; set; }
    }
}
