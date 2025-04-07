using OtoServisSatis.Data;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.Service.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace OtoServisSatis.WebUI
{
    public class Program
    {
        public static void Main(string[] args) 
        { 


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(); //MVC

            _ = builder.Services.AddDbContext<DatabaseContext>(); //DatabaseContext

            builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));
            builder.Services.AddTransient<IDmrbsService, DmrbsService>();
            builder.Services.AddTransient<IUserService, UserService>();



            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Account/Login"; //giri� yapma
                    x.AccessDeniedPath = "/AccessDenied"; //yetkisiz eri�im
                    x.LogoutPath = "/Account/Logout"; //��k�� yapma
                    x.Cookie.Name = "Admin"; //cookie ad�
                    x.Cookie.MaxAge = TimeSpan.FromDays(7); //cookie s�resi
                    x.Cookie.IsEssential = true; //cookie zorunlu
                });

            builder.Services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin")); //sadece admin eri�ebilir
                x.AddPolicy("UserPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "User")); //admin ve user eri�ebilir
                x.AddPolicy("CustomerPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "User", "Customer")); //markalara sadece admin eri�ebilir


            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())   
            {
                app.UseExceptionHandler("/Home/Error"); //hata y�nlendirme
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                    name: "admin",
                    pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
                  ); //admin paneli

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); //anasayfa

            app.Run();


        }
    }
}