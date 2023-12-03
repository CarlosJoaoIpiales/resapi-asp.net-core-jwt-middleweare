using actividad_6.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace actividad_6.Controllers
{
    //[Authorize(Policy = "Enter")] // Aplica la política de autorización
    [Route("api/[controller]")]
    [ApiController]
    public class LoginUserController : ControllerBase
    {
        /*Aqui traemos los datos de la base de datos*/
        private readonly actividad_6.Data.actividad_6Context _data;
        public LoginUserController(actividad_6.Data.actividad_6Context data) {
            _data = data;
        }


        /* Aqui creamos la funcion que llamara a la funcion que autentificara
         los usuarios del login*/
        [HttpPost]
        public IActionResult Login(Models.Login login)
        {
            var user = Autentification(login);
            if (user == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            // Generar el token JWT
            var token = GenerateJwtToken(user);

            return Ok(new { token });
        }

        // Método para generar el token JWT (implementa tu lógica aquí)
        private string GenerateJwtToken(Models.Usuarios user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("xTNE|~zf!a9YX$)i,ovls|y{}]_&k,9*\r\n")); // Reemplaza con tu clave secreta
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.Nombres),
        // Agrega aquí otros claims según sea necesario
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var token = new JwtSecurityToken(
                issuer: "https://localhost:7011", // Reemplaza con tu emisor
                audience: "Usuarios", // Reemplaza con tu audiencia
                claims: claims,
                expires: DateTime.Now.AddHours(1), // Tiempo de expiración del token
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /*Aqui se encuentra la funcion que autentificara el usuario y la contraseña*/
        private Models.Usuarios Autentification(Models.Login user) {
            /* Se crea una variable donde llamamos a los datos recuperados de la base de 
             datos y lo comparamos con los datos enviados a la api res*/
            var userLogin = _data.Usuarios.FirstOrDefault(e => e.Nombres == user.Usuario && e.Contrasenia == user.Password);
            if (userLogin != null)
            {
                return userLogin;
            }
            else
            {
                return null;
            }
        }

       
    }
}
