using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SwiftCarpenter.Infraestructure.Data;
using swiftcarpenterApi.Infraestructure.Repositories;
using swiftcarpenterApi.Services.Features.Customers;
using swiftcarpenterApi.Services.Features.DetailQuotes;
using swiftcarpenterApi.Services.Features.Products;
using swiftcarpenterApi.Services.Features.Quotes;
using swiftcarpenterApi.Services.Mappings;
using System.Text;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(ResponseMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(RequestCreateMappingProfile).Assembly);

builder.Services.AddIdentity<IdentityUser, IdentityRole>().
    AddEntityFrameworkStores<SwiftCarpenterDbContext>().
    AddDefaultTokenProviders();
    


var Configuration = builder.Configuration;

builder.Services.AddScoped<ProductService>();


builder.Services.AddTransient<ProductRepository>();
builder.Services.AddScoped<QuoteService>();
builder.Services.AddTransient<QuoteRepository>();
builder.Services.AddScoped<DetailQuoteService>();
builder.Services.AddTransient<DetailQuoteRepository>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddTransient<CustomerRepository>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowSpecificOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
                  
        });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("EstaEsLaClaveMásFuerteQueVerás")),
        ClockSkew = TimeSpan.Zero
    });

builder.Services.AddControllers();
builder.Services.AddDbContext<SwiftCarpenterDbContext>(
    options => {
        options.UseSqlServer(Configuration.GetConnectionString("gemDevelopment"));
    }
);


var app = builder.Build();

app.UseCors("_myAllowSpecificOrigins");
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
