using Highlights;
using Newtonsoft.Json;
using System.Text;

namespace ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI(options
                => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Gateway"));

            app.UseHttpsRedirection();

            app.UseAuthorization();

            string path = "http://localhost";

            app.MapGet("/api/listMembers", async (IHttpClientFactory httpClientFactory) =>
            {
                var httpClient = httpClientFactory.CreateClient();

                var apiUrl = $"{path}:3001/api/members";

                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Results.Ok(JsonConvert.DeserializeObject<List<MemberDto>>(content));
                }
                else
                {
                    return Results.BadRequest("Error al consumir la API Memebers");
                }
            });

            app.MapGet("/api/listBookings", async (IHttpClientFactory httpClientFactory) =>
            {
                var httpClient = httpClientFactory.CreateClient();

                var apiUrl = $"{path}:3002/api/bookings";

                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Results.Ok(JsonConvert.DeserializeObject<List<BookingDto>>(content));
                }
                else
                {
                    return Results.BadRequest("Error al consumir la API Bookings");
                }
            });

            app.MapPost("/api/login", async (IHttpClientFactory httpClientFactory, LoginDto login) =>
            {
                var httpClient = httpClientFactory.CreateClient();

                var apiUrl = $"{path}:3003/api/identity/login";

                var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(login), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(apiUrl, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Results.Ok(content);
                }
                else
                {
                    return Results.BadRequest("Error al consumir la API Identity");
                }
            });

            app.MapGet("/api/listHighlights", async (IHttpClientFactory httpClientFactory) =>
            {
                var httpClient = httpClientFactory.CreateClient();

                var apiUrl = $"{path}:3004/api/highlight";

                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Results.Ok(JsonConvert.DeserializeObject<List<HighlightDto>>(content));
                }
                else
                {
                    return Results.BadRequest("Error al consumir la API Highlights");
                }
            });

            app.Run();
        }
    }
}