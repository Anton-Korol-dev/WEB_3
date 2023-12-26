using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;
using WEB3.Areas.Identity.Data;
using WEB3.Entities;

namespace WEB3.Data;

public class WEB3Context : IdentityDbContext<WEB3User>
{
    public DbSet<User> Users { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public WEB3Context(DbContextOptions<WEB3Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
