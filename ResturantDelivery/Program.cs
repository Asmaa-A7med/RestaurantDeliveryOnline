
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResturantDelivery.Data;
using ResturantDelivery.MapperConfigs;
using ResturantDelivery.Models;
using ResturantDelivery.Reposetories;
using ResturantDelivery.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;


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
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<CustomerService>();

            builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();

            builder.Services.AddAuthentication(option =>
     option.DefaultAuthenticateScheme = "myscheme")
 .AddJwtBearer("myscheme", op =>
 {
     string key = builder.Configuration["JWT:Key"];
     var sercertKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
     op.TokenValidationParameters = new TokenValidationParameters
     {
         IssuerSigningKey = sercertKey,
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidIssuer = builder.Configuration["JWT:Issuer"],
         ValidAudience = builder.Configuration["JWT:Audience"],
         ValidateLifetime = true
     };
 });
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
            app.UseAuthentication();
            app.UseAuthorization();



            app.MapControllers();

            app.Run();
        }
    }
}
