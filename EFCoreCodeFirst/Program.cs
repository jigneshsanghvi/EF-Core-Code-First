using EFCoreCodeFirst.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//cookies authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Login/Login";
        x.AccessDeniedPath = "/Login/AccessDenied";
    });

// authentication policy
builder.Services.AddAuthorization(options
=>
{
    options.AddPolicy("MyAccessPolicy",
    policy => {
        policy.RequireRole("Admin");
        policy.RequireUserName("jignesh");
    });
});

//Register DBContext
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<StudentDBContext>(item => item.UseSqlServer(config.GetConnectionString("TestConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

// migration dynamically
app.MigrateDatabase();

app.Run();
