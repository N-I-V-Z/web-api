
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyWebAPI.Data;
using System.Text;

namespace MyWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));
            });
            
            builder.Services.AddEndpointsApiExplorer()
                ;
            builder.Services.AddAuthorization();

            var secretKey = builder.Configuration["AppSetting:SecretKey"];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    //tự cấp token 
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    //ký vào token 
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                    ClockSkew = TimeSpan.Zero
                };

            });
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
