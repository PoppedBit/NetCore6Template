using DotNetCore6Test.Context;
using DotNetCore6Test.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    {
        options.Cookie.Name = builder.Configuration["AppSettings:Cookie"];
        // 8 Hours expiration time
        options.ExpireTimeSpan = new TimeSpan(8, 0, 0);
        // Reissues a cookie if a request is handled when more than halfway through expiration window
        options.SlidingExpiration = true;
    }
);

builder.Services.AddDbContext<DataContext>();

//HTTP Context Accessor
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// My Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IForumService, ForumService>();

var app = builder.Build();

app.UseHttpsRedirection();

// Routing for login app
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "UI/login/build")),
    RequestPath = "/Login"
});
// Routing for client app
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "UI/client/build")),
    RequestPath = "/Client"
});


app.UseAuthentication();
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
