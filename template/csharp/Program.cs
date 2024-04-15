using function;

var builder = WebApplication.CreateBuilder(args);

FaaSEndpoints.MapServices(builder.Services);

var app = builder.Build();

FaaSEndpoints.Map(app);

app.Run("http://127.0.0.1:3000");
