using function;

var builder = WebApplication.CreateBuilder(args);

Handler.MapServices(builder.Services);

var app = builder.Build();

Handler.MapEndpoints(app);

app.Run("http://127.0.0.1:3000");
