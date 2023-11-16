namespace Members
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
                => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Microservice Members"));

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/api/members", (HttpContext httpContext) =>
            {
                return new List<MemberDto>()
                {
                    new MemberDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "Alexis",
                        Surname = "Angulo",
                        Email = "alexis@prueba.com",
                        MemberType = "Cliente"
                    },
                    new MemberDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "Leidy",
                        Surname = "Cabezas",
                        Email = "leidy@prueba.com",
                        MemberType = "Negocio"
                    }
                };
            })
            .WithName("GetMember");

            app.Run();
        }
    }
}