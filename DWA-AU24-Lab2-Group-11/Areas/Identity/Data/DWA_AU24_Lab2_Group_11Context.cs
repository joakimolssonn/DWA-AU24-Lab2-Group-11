using DWA_AU24_Lab2_Group_11.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DWA_AU24_Lab2_Group_11.Data;

public class DWA_AU24_Lab2_Group_11Context : IdentityDbContext<User>
{
    public DWA_AU24_Lab2_Group_11Context(DbContextOptions<DWA_AU24_Lab2_Group_11Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
