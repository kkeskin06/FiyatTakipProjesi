using GoraYazilim.Business;
using GoraYazilim.Business.Interface;
using GoraYazilim.DataAccess;
using GoraYazilim.DataAccess.Interface;
using GoraYazilim.DataAccess.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PriceTrackingContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Constring")));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
        options =>
        {
            options.LoginPath = new PathString("/Security/Login");
           
        });

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();



builder.Services.AddScoped<IAlturunDao, AlturunDao>();
builder.Services.AddScoped<IFiyatlandirmaDao, FiyatlandirmaDao>();
builder.Services.AddScoped<IUrunDao, UrunDao>();
builder.Services.AddScoped<IKategoriDao, KategoriDao>();
builder.Services.AddScoped<ISaticiDao, SaticiDao>();
builder.Services.AddScoped<IKategoriBc, KategoriBc>();
builder.Services.AddScoped<ISaticiBc, SaticiBc>();
builder.Services.AddScoped<IUrunBc, UrunBc>();
builder.Services.AddScoped<IAlturunBc, AlturunBc>();
builder.Services.AddScoped<IFiyatlandirmaBc, FiyatlandirmaBc>();
builder.Services.AddScoped<DbContext, PriceTrackingContext>();





var app = builder.Build();
app.UseAuthentication();

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
    pattern: "{controller=Security}/{action=login}/{id?}");


app.Run();


//using GoraYazilim;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GoraYazilim
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            CreateHostBuilder(args).Build().Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });
//    }
//}


