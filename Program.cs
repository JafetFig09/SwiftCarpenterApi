using Microsoft.EntityFrameworkCore;
using SwiftCarpenter.Infraestructure.Data;
using swiftcarpenterApi.Infraestructure.Repositories;
using swiftcarpenterApi.Services.Features.Customers;
using swiftcarpenterApi.Services.Features.DetailQuotes;
using swiftcarpenterApi.Services.Features.Products;
using swiftcarpenterApi.Services.Features.Quotes;
using swiftcarpenterApi.Services.Mappings;
// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ResponseMappingProfile).Assembly);



var Configuration = builder.Configuration;

builder.Services.AddScoped<ProductService>();
builder.Services.AddAutoMapper(typeof(RequestCreateMappingProfile).Assembly);


builder.Services.AddTransient<ProductRepository>();

builder.Services.AddScoped<QuoteService>();
builder.Services.AddTransient<QuoteRepository>();

builder.Services.AddScoped<DetailQuoteService>();
builder.Services.AddTransient<DetailQuoteRepository>();


builder.Services.AddScoped<CustomerService>();
builder.Services.AddTransient<CustomerRepository>();





builder.Services.AddControllers();
builder.Services.AddDbContext<SwiftCarpenterDbContext>(
    options => {
        options.UseSqlServer(Configuration.GetConnectionString("gemDevelopment"));
    }
);

var app = builder.Build();

app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();



app.Run();
