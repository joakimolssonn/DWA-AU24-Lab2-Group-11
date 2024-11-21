using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DWA_AU24_Lab2_Group_11.Data;
using DWA_AU24_Lab2_Group_11.Services;
using Microsoft.AspNetCore.Identity;
using DWA_AU24_Lab2_Group_11.Models;
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

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DWA_AU24_Lab2_Group_11Context>();


            builder.Services.AddHostedService<NotificationService>();
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
    }
}
