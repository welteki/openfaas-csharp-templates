using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace function;
public static class Handler
{
    public static void MapServices(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // register additional services
    }

    public static void MapEndpoints(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.MapGet("/", () =>
        {
            return "Hello world!!!";
        })
        .WithOpenApi();
    }
}