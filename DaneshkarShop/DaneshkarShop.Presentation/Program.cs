using DaneshkarShop.Application.Services.Implementation;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Data.AppDbContext;
using DaneshkarShop.Data.Repositories;
using DaneshkarShop.Domain.IRepositories;
using DaneshkarShop.IoC;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DaneshkarShop.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        #region Builder

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        #region Context

        builder.Services.AddDbContext<DaneshkarDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DaneshkarDbContextConnectionString"));
        });

        #endregion

        #region Authentication

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
            // Add Cookie settings
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Logout";
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
            });

        #endregion

        #region IoC

        RegisterServices(builder.Services);

        #endregion

        var app = builder.Build();

        #endregion

        #region App Services

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

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "MyAreas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );
            endpoints.MapControllerRoute(
                name: "Default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );
        });

        app.Run();

        #endregion

    }

    public static void RegisterServices(IServiceCollection services)
    {
        DependencyContainer.RegisterServices(services);
    }
}