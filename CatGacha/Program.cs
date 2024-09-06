/*using Microsoft.AspNetCore.Authentication.Cookies;*/
using CatGacha.Core.Domain;
using CatGacha.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Database context 
        builder.Services.AddDbContext<CatGachaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CatGachaConnection")));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        // user
        builder.Services.AddIdentity<ApplicationUser, IdentityRole> (options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<CatGachaContext>()
            .AddDefaultTokenProviders()
            .AddDefaultUI();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
/*        app.UseCookiePolicy(cookiePolicyOptions);*/
        app.UseHttpsRedirection();
        app.UseStaticFiles();  //later add here multiplefileupload

        app.UseRouting();

        app.UseAuthentication();
/*        app.UseAuthorization();*/

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}