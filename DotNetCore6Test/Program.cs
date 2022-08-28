using DotNetCore6Test.Context;
using DotNetCore6Test.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// My Services
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.UseHttpsRedirection();

// Routing for login app
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "UI/login/build")),
    RequestPath = "/Login"
});

app.UseAuthorization();

app.MapControllers();

// migrate any database changes on startup (includes initial db creation)
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dataContext.Database.Migrate();
}

app.Run();

// Set up DB Context with this
// https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0
