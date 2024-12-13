using Authenticate_Key_Endpoint_Filters.Filters;
using Authenticate_Key_Endpoint_Filters.Services;

namespace Authenticate_Key_Endpoint_Filters
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddTransient<IApiKeyValidation, ApiKeyValidation>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("api/secure/home", () =>
            {
                return Results.Ok(new { message = "Welcome to Home" });

            }).AddEndpointFilter<ApiKeyEndpointFilter>();

            app.MapGet("api/secure/about", () =>
            {
                return Results.Ok(new { message = "Welcome to About" });

            });

            //app.MapControllers();

            app.Run();
        }
    }
}
