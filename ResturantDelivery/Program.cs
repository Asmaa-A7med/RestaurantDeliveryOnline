
using Microsoft.EntityFrameworkCore;
using ResturantDelivery.Data;
using ResturantDelivery.MapperConfigs;
using ResturantDelivery.Reposetories;
using ResturantDelivery.Services;

namespace ResturantDelivery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ResturantDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


             builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        //    builder.Services.AddAutoMapper(typeof(RestaurantProfile));


            builder.Services.AddScoped<RestaurantRepo>();
            builder.Services.AddScoped<citiyRepo>();



            builder.Services.AddScoped<UnitOfWork>();

            builder.Services.AddScoped<ResturantService>();
            builder.Services.AddScoped<cityService>();


            // Define CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")  
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAngularApp");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
