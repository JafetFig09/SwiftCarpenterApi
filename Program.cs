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
//builder.Services.AddSwaggerGen( c =>
//{
//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Name = "Authorization",
//        Type = SecuritySchemeType.ApiKey,
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header
//    });

//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        new OpenApiSecurityScheme
//        {
//            Reference = new OpenApiReference
//            {
//                Type = ReferenceType.SecurityScheme,
//                Id = "Bearer"

//            }
//        },
//        new String[]{}
//    }) ;

//});

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


builder.Services.AddAutoMapper(typeof(ResponseMappingProfile).Assembly);

builder.Services.AddIdentity<IdentityUser, IdentityRole>().
    AddEntityFrameworkStores<SwiftCarpenterDbContext>().
    AddDefaultTokenProviders();
    


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

app.UseSwagger();

app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();



app.Run();
