using Travello_Infrastructure.DependencyInjection;
using Travello_Application.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
#region Register Services
// Infrastructure services registration
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddCloudinaryServices(builder.Configuration);
// Application services registration
builder.Services.AddApplicationServices();
#endregion



builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

