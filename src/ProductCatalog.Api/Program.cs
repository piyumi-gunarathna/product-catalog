using Microsoft.EntityFrameworkCore;
using ProductCatalog.Api.RequestHandlers;
using ProductCatalog.Domain;
using ProductCatalog.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<CreateProductHandler>();
builder.Services.AddTransient<GetProductsHandler>();

var connectionString = Environment.GetEnvironmentVariable("ProductCatalogConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    connectionString = builder.Configuration.GetConnectionString("ProductCatalogConnection");
}

builder.Services.AddDbContext<ProductCatalogDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

