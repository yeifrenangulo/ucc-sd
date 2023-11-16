namespace Identity
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
                => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservice Identity"));

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapPost("/api/identity/login", (LoginDto login) =>
            {
                return Results.Ok("Inicio sesión!!!");
            })
            .WithName("PostIdentity");

            app.Run();
        }
    }
}