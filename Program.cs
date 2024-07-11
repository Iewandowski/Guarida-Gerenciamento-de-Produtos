using gerenciamento_de_produto.Repository.Implementation;
using gerenciamento_de_produto.Repository;
using gerenciamento_de_produto.Service.Implementation;
using gerenciamento_de_produto.Service;
using gerenciamento_de_produto.Data;
using System.Data;
using gerenciamento_de_produto.config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDbConnection>(sp =>
{
    var dbInitializer = new DbInitializer();
    return dbInitializer.GetConnection();
});

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gerenciamento de Produto API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ValidationMiddleware>();

app.MapControllers();

app.Run();
