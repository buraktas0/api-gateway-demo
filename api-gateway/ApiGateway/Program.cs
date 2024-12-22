
namespace ApiGateway;

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

        builder.Services.AddReverseProxy()
            .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));


        var app = builder.Build();


        app.MapReverseProxy();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            // app.UseSwaggerUI(options =>
            // {
            //     // Mikroservislerin Swagger Endpoint'lerini ekleyin
            //     // options.SwaggerEndpoint("http://localhost:5002/swagger/v1/swagger.json", "Product Service API");
            //     // options.SwaggerEndpoint("http://localhost:5003/swagger/v1/swagger.json", "Stock Service API");
            //     // options.SwaggerEndpoint("http://localhost:5004/swagger/v1/swagger.json", "Weather Service API");
            // });

        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
