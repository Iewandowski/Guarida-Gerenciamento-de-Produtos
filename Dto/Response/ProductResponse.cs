namespace gerenciamento_de_produto.Dto.Response
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ProductResponse(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public ProductResponse() { }
    }
}
