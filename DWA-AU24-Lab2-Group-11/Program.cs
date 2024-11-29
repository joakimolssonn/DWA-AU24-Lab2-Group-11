using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DWA_AU24_Lab2_Group_11.Data;
using DWA_AU24_Lab2_Group_11.Services;
using Microsoft.AspNetCore.Identity;
using DWA_AU24_Lab2_Group_11.Models;
using Task = System.Threading.Tasks.Task;

namespace DWA_AU24_Lab2_Group_11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<FarmTrackContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FarmTrackContext") ?? throw new InvalidOperationException("Connection string 'FarmTrackContext' not found.")));

            builder.Services.AddDbContext<DWA_AU24_Lab2_Group_11Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DWA_AU24_Lab2_Group_11Context") ?? throw new InvalidOperationException("Connection string 'DWA_AU24_Lab2_Group_11Context' not found.")));

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DWA_AU24_Lab2_Group_11Context>();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            });

            builder.Services.AddHostedService<NotificationService>();
            builder.Services.AddHttpClient<WeatherApiService>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Seed the admin user
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                SeedAdminUser(services).Wait();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();
            app.Run();
        }

        public static async Task SeedAdminUser(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string adminEmail = "admin@example.com";
            string adminPassword = "Admin@123";

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    LastName = "User",
                    Location = "Headquarters",
                    Latitude = 0.0,
                    Longitude = 0.0
                };
                await userManager.CreateAsync(adminUser, adminPassword);
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
