using AutoMapper;
using LarsV2.Models.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LarsV2.Controllers
{
    [ApiController]
    [Route("api/identity")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class IdentityController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public IdentityController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration configuration, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(_userManager.Users);

            return Ok(usersDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]UserCreateDto newUser)
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { UserName = newUser.Username, Email = newUser.Email };
                IdentityResult result = await _userManager.CreateAsync(user, newUser.Password);

                if (result.Succeeded)
                {
                    return NoContent();
                }

                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            IdentityUser user = await _userManager.FindByIdAsync(userId);

            if(user == null)
            {
                return NotFound();
            }

            if(user.UserName.ToLower() ==  "admin")
            {
                return StatusCode(StatusCodes.Status405MethodNotAllowed);
            }

            await _userManager.DeleteAsync(user);
            return NoContent();       
        }
  
        [HttpPut("Password")]
        public async Task<IActionResult> ChangePassword([FromBody]PasswordChangeDto passwordDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var result = await _userManager.ChangePasswordAsync(user, passwordDto.CurrentPassword, passwordDto.NewPassword);

                if (result.Succeeded)
                {
                    return NoContent();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return BadRequest(ModelState);
        }
        
        [HttpPost("CreateToken")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateToken([FromBody]LoginDto login)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(login.Username);
                if (user == null)
                {
                    return BadRequest();
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

                if (result.Succeeded)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

                    var token = new JwtSecurityToken(
                        _configuration["Token:Issuer"],
                        _configuration["Token:Audience"],
                        claims,
                        signingCredentials: creds,
                        expires: DateTime.UtcNow.AddHours(1));

                    return Created("", new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
            }

            return Unauthorized();
        }
    }
}