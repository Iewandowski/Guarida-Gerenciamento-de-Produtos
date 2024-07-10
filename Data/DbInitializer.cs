using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;

namespace gerenciamento_de_produto.Data
{
    public class DbInitializer
    {
        private readonly IDbConnection _connection;

        public DbInitializer()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
            Initialize();
        }

        public IDbConnection GetConnection() => _connection;

        private void Initialize()
        {
            var createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Product (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Price REAL NOT NULL
                )";
            _connection.Execute(createTableQuery);

            var insertDataQuery = @"
                INSERT INTO Product (Name, Price) VALUES 
                ('Produto 1', 10.0), 
                ('Produto 2', 20.0), 
                ('Produto 3', 30.0)";
            _connection.Execute(insertDataQuery);

        }
    }
}

