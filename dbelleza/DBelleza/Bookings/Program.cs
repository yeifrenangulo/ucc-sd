namespace Bookings
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
                => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservice Bookings"));

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/api/bookings", (HttpContext httpContext) =>
            {
                return new List<BookingDto>()
                {
                    new BookingDto
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Now,
                        CustomerName = "Alexis Angulo"
                    },
                    new BookingDto
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Now,
                        CustomerName = "Yeifren Angulo"
                    },
                    new BookingDto
                    {
                        Id = Guid.NewGuid(),
                        StartDate = DateTime.Now,
                        CustomerName = "Pepito Perez"
                    }
                };
            })
            .WithName("GetBookings");

            app.Run();
        }
    }
}