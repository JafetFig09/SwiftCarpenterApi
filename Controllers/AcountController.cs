using Microsoft.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using swiftcarpenterApi.Domain.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using SwiftCarpenter.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using SwiftCarpenter.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace swiftcarpenterApi.Controllers
{
    [ApiController]
    [Route("api/Counts")]
    public class AcountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly SwiftCarpenterDbContext _context;

        public AcountController(IMapper mapper, SwiftCarpenterDbContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCreateDTO request)
        {
            var usuario = await _context.Customers.FirstOrDefaultAsync(a => a.Email == request.Email && a.PasswordCustomer == request.Password);
            if (usuario == null)
            {
                return BadRequest("Usuario o contraseña incorrectos");
            }

           
            // Generar el token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ThisIsTheStrongestKeyThatYouWillSee"); // Reemplaza con tu clave secreta
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()), // Agregar el ID como claim
                new Claim(ClaimTypes.Name, usuario.CustomerName),
                new Claim(ClaimTypes.Email, usuario.Email), // Agregar el correo como claim

                //new Claim(ClaimTypes.)

                }),
                Expires = DateTime.UtcNow.AddDays(1), // Define la expiración del token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }

        [HttpPost("logout")]
        public IActionResult Logout(string token)
        {
            return Ok(new { message = "Logout successful" });
        }
    }

    public class LoginCreateDTO
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }

}
