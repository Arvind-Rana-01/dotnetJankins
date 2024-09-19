using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ToolMonitoringServices.DataAccess;
using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
       

            private IConfiguration _config;
            public AppDbContext _context;

            public AuthController(IConfiguration configuration, AppDbContext context)
            {
                _config = configuration;
                _context = context;
            }

            private GetAdmin AuthenticateUser(string username, string password)
            {

                GetAdmin authenticatedUser = _context.User.FirstOrDefault(u => u.Username == username && u.Password == password);
                return authenticatedUser;
            }

            private string GenerateToken(GetAdmin user)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var crediential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                    expires: DateTime.Now.AddMinutes(1),
                    signingCredentials: crediential
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }


            [AllowAnonymous]
            [HttpPost]
            public IActionResult Login(GetAdmin user)
            {
                try
                {
                    IActionResult response = Unauthorized();
                    var user_ = AuthenticateUser(user.Username, user.Password);
                    if (user_ != null)
                    {
                        var token = GenerateToken(user_);
                        response = Ok(new { token = token });

                    }
                    return response;
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("UserName and Password are incorrect");
                    return BadRequest(ex.Message);
                }
            }
        }
    }
