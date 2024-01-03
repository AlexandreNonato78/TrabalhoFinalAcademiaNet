using Microsoft.AspNetCore.Hosting;
using TrabalhoFinalAcademiaNet.Repositories.Interfaces;
using TrabalhoFinalAcademiaNet.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Localization;
using TrabalhoFinalAcademiaNet.Models;

namespace TrabalhoFinalAcademiaNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<Contexto>(
        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddMemoryCache();
            builder.Services.AddSession();
            //builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
            //builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

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
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
