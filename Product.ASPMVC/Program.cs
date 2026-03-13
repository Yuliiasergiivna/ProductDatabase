using Microsoft.Data.SqlClient;
using ProductLibrary.Common;
using ProductLibrary.BLL.Services;
using ProductLibrary.DAL.Services;


namespace ProductLibrary.ASPMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<SqlConnection>(options => new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductDatabase;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;"));

            builder.Services.AddScoped<IUserRepository<BLL.Entities.User>, BLL.Services.UserService>();
            builder.Services.AddScoped<IProductRepository<BLL.Entities.Product>, BLL.Services.ProductService>();
            builder.Services.AddScoped<IProductRepository<DAL.Entities.Product>, DAL.Services.ProductService>();

            builder.Services.AddScoped<IStockRepository<DAL.Entities.StockEntry>, DAL.Services.StockEntryService>();



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
                pattern: "{controller=Product}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
