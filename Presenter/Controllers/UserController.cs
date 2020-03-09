using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ValidationWithMediatr_task.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ValidationWithMediatr_task.Presenter.Controllers
{
    [ApiController]
    [Route("authenticate")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult Authenticate(UserD user)
        {
            var users = new List<UserD>()
            {
                new UserD() { Username="nugi", Password="aaaa"},
                new UserD() { Username="nugi2", Password="aaaa"}
            };

            var _user = users.Find(e => e.Username == user.Username);

            var tokenHandler = new JwtSecurityTokenHandler();
            
             var tokenDescription = new SecurityTokenDescriptor(){
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, _user.Username),
                    new Claim(ClaimTypes.Sid, _user.Password)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ini secret key")), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            var tokenResponse = new
            {
                token = tokenHandler.WriteToken(token),
                user = _user.Username
            };

            return Ok(tokenResponse);
        }
    }
}