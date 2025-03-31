using WebAPI.Services.Abstractions;
using WebAPI.Services.Implementations;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ITestService, TestService>();

WebApplication app = builder.Build();

app.MapGet("/double",
    (int input, ITestService testService)
    => testService.Double(input));

app.Run();
