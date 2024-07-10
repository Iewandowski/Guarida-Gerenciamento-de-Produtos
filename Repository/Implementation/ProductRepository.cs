using gerenciamento_de_produto.Model;
using System.Data;
using Dapper;

namespace gerenciamento_de_produto.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var query = "SELECT * FROM Product";
            return await _connection.QueryAsync<Product>(query);
        }

        public async Task<Product?> GetById(int id)
        {
            var query = "SELECT * FROM Product WHERE Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
        }

        public async Task<Product> CreateProduct(Product product)
        {
            string insertSql = "INSERT INTO Product (Name, Price) VALUES (@Name, @Price);" +
                               "SELECT last_insert_rowid();";

            int productId = await _connection.ExecuteScalarAsync<int>(insertSql, product);

            product.Id = productId;
            return product;
        }

        public async Task UpdateProduct(Product product)
        {
            _connection.Open();
            await _connection.ExecuteAsync("UPDATE Product SET Name = @Name, Price = @Price WHERE Id = @Id", product);
        }

        public async Task DeleteProduct(Product product)
        {
            _connection.Open();
            await _connection.ExecuteAsync("DELETE FROM Product WHERE Id = @Id", new { Id = product.Id });
        }
    }
}
