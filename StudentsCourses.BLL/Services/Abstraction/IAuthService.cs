using StudentsCourses.BLL.Dto.Auth;
using StudentsCourses.BLL.Dto.Course;
using StudentsCourses.BLL.ResponseResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsCourses.BLL.Services.Abstraction
{
    public interface IAuthService
    {
        Task<Response<string>> LoginAsync(LoginDto loginDto);
        Task<Response<bool>> RegisterAsync(RegisterDto registerDto);
    }
}
