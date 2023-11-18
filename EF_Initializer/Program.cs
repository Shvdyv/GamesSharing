using GameSharing.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace EF_Initializer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
#if DEBUG
            var connectionString = builder.Configuration.GetConnectionString("System");
#else
var connectionString = builder.Configuration.GetConnectionString("PRODUKCJA");
#endif

            builder.Services.AddDbContext<Database>(x => x.UseSqlServer(connectionString));
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            builder.Services.AddAuthorization();
            builder.Services.AddAntiforgery();
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Home/Login";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Home/Login";
                //options.Cookie.Name = "GamesSharing";
            });
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());
            app.Run();
        }
    }
}
