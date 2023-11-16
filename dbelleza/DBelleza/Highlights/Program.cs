namespace Highlights
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
                => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservice Highlight"));

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/api/highlight", (HttpContext httpContext) =>
            {
                return new List<HighlightDto>()
                {
                    new HighlightDto
                    {
                        Id = Guid.NewGuid(),
                        NameBussiness = "Peluquería MyLady",
                        Assessment = "4.9"
                    },
                    new HighlightDto
                    {
                        Id = Guid.NewGuid(),
                        NameBussiness = "Spa de uñas",
                        Assessment = "4.5"
                    },
                    new HighlightDto
                    {
                        Id = Guid.NewGuid(),
                        NameBussiness = "El Barbero",
                        Assessment = "4.2"
                    },
                };
            })
            .WithName("GetHighlight");

            app.Run();
        }
    }
}