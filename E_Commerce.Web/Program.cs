
using Microsoft.EntityFrameworkCore;
using Presistance.Data;

namespace E_Commerce.Web
{
    public class Program
    {
        public static void Main(string[] args)
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
            #endregion

            var app = builder.Build();

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
    }
}
