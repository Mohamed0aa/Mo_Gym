
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Mo_Api_Talabat.Extensions;
using Mo_Api_Talabat.Services;
using Mo_Api_Talabat_Controllers.Controllers;
using Share;
using Mo_Talabat_Infrastructure_presistence;
using Mo_Talabat_Core_Application;
namespace Mo_Api_Talabat
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddApplicationPart(typeof(BaseApiController).Assembly);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Addpresistence(builder.Configuration);
            builder.Services.AddApplicationServices();
            builder.Services.AddScoped<ILoggedInUser, LoggedInUser>();
            builder.Services.AddHttpContextAccessor();
            ////////////////////////////////////////////////////////////////////////////////////
            var app = builder.Build();
            await app.InitializerStoreContext();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
