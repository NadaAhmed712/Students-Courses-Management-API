using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StudentsCourses.BLL.Mapper;
using StudentsCourses.BLL.Services.Abstraction;
using StudentsCourses.BLL.Services.Impelementation;
using StudentsCourses.DAL.Database;
using System.Text;

namespace StudentsCourses.DAL.Common
{
    public static class ModularDataAcessLayer
    {
        public static IServiceCollection AddBusinessInBLL(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

            var connectionString = configuration.GetConnectionString("defaultConnection");

            services.AddDbContext<StudentsCoursesDbContext>(options =>
            options.UseSqlServer(connectionString));
            // Identity

            services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<StudentsCoursesDbContext>() 
            .AddDefaultTokenProviders();


            // Add JWT Authentication
            IConfigurationSection jwtSettings = configuration.GetSection("Jwt");
            byte[] key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            services.AddScoped<JwtTokenHandlerService>();

            return services;

        }
    }
}
