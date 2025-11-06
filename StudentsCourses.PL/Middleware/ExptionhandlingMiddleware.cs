using System.Text.Json;

namespace StudentsCourses.Middleware
{
    public class ExptionhandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExptionhandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;
                var response = new
                {
                    message = "Something went wrong, please try again later.",
                    statusCode = context.Response.StatusCode
                };

                var jsonResponse = JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}
