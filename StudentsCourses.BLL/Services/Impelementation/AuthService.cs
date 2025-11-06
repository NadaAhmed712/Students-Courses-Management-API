using Microsoft.AspNetCore.Identity;
using StudentsCourses.BLL.Dto.Auth;
using StudentsCourses.BLL.ResponseResult;
using StudentsCourses.BLL.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsCourses.BLL.Services.Impelementation
{
    internal class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JwtTokenHandlerService _jwtHandler;

        public AuthService(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            JwtTokenHandlerService jwtHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtHandler = jwtHandler;
        }
        public async Task<Response<string>> LoginAsync(LoginDto loginDto)
        {

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return new Response<string>(null, "Invalid email or password", true);

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
                return new Response<string>(null, "Invalid email or password", true);


            string token = _jwtHandler.GenerateToken("Admin");

            return new Response<string>(token, null, false);
        }

        public async Task<Response<bool>> RegisterAsync(RegisterDto registerDto)
        {
            var user = new IdentityUser()
            {
                Email = registerDto.Email,
                PasswordHash = registerDto.Password,
                UserName = registerDto.UserName
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                return new Response<bool>(true, null, false);
            }
            else
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));

                return new Response<bool>(false, errors, true);
            }
        }
    }
}
