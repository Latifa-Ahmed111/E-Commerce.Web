
using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using Presistance.Data;
using Presistance.Reposatories;
using Service;
using ServiceAbstraction;

namespace E_Commerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Sevices 
            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                var ConnectiionString = builder.Configuration.GetConnectionString("DefualtConnection");
                options.UseSqlServer(ConnectiionString);

            });

            builder.Services.AddScoped<IDbIntializer, DbIntializer>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(AssiemblyRefrencres).Assembly);
            builder.Services.AddScoped<ISevicesManger, ServicesMange>();
            #endregion




            var app = builder.Build();

            await intializeDbAsync(app);

            #region // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            #endregion 
            app.Run();
        }


        public static async Task intializeDbAsync(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbintializer = scope.ServiceProvider.GetRequiredService<IDbIntializer>();
            await dbintializer.IntializeAsync();

        }
    }
}
