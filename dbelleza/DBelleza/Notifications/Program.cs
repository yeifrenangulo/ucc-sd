namespace Notifications
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI(options
                => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservice Notifications"));

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/sendNotification", (HttpContext httpContext) =>
            {
                return Results.Ok("Enviando notificaciones!!!");
            })
            .WithName("GetNotification");

            app.Run();
        }
    }
}