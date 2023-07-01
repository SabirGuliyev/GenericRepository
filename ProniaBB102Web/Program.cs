using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProniaBB102Web.DAL;
using ProniaBB102Web.Interfaces;
using ProniaBB102Web.Middlewares;
using ProniaBB102Web.Models;
using ProniaBB102Web.Repositories.Implementations;
using ProniaBB102Web.Repositories.Interfaces;
using ProniaBB102Web.Repositories.Interfaces.Generic;
using ProniaBB102Web.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(50);
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireUppercase = true;

    options.User.RequireUniqueEmail = true;

    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.Lockout.AllowedForNewUsers = true;

}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddScoped<LayoutService>();
builder.Services.AddScoped<IEmailService,EmailService>();

builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<ITagRepository,TagRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();
app.UseStaticFiles();
//app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.MapControllerRoute(

    name: "Areas",
    pattern: "{area:exists}/{controller=home}/{action=index}/{id?}"

    );
app.MapControllerRoute(

    name:"Default",
    pattern:"{controller=home}/{action=index}/{id?}"

    );

app.Run();
