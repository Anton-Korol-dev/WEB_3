using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WEB3.Abstraction;
using WEB3.Areas.Identity.Data;
using WEB3.Data;
using WEB3.Services;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WEB3ContextConnection") ?? throw new InvalidOperationException("Connection string 'WEB3ContextConnection' not found.");

builder.Services.AddDbContext<WEB3Context>(options => options.UseSqlite(connectionString));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDefaultIdentity<WEB3User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WEB3Context>();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>(serviceProvider =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    return new SqlConnectionFactory(configuration);
});

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WEB4 v1"));
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapRazorPages();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
