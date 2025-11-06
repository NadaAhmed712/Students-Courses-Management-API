using Microsoft.Extensions.DependencyInjection;
using StudentsCourses.DAL.Repo.Abstraction;
using StudentsCourses.DAL.Repo.Impelementation;

namespace StudentsCourses.DAL.Common
{
    public static class ModularDataAcessLayer
    {
        public static IServiceCollection AddBusinessInDAL(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepo, StudentRepo>();
            services.AddScoped<ICourseRepo, CourseRepo>();
            return services;
        }
    }
}
