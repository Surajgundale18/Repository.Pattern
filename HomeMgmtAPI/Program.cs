using FluentValidation;
using HomeMgmtAPI.BusinessLayer.Mappers;
using HomeMgmtAPI.BusinessLayer.Services;
using HomeMgmtAPI.BusinessLayer.Validators;
using HomeMgmtAPI.DataLayer;
using HomeMgmtAPI.DataLayer.Repositories;
using HomeMgmtAPI.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Text;

namespace HomeMgmtAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<HomeDbContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("HomeData")));

            // Repository
            builder.Services.AddScoped<IHomeRepository, SqlHomeRepository>();
            builder.Services.AddScoped<IRoomRepository, SqlRoomRepository>();
            builder.Services.AddScoped<IAddressRepository, SqlAddressRepository>();
            builder.Services.AddScoped<IUserRepositoy, SqlUserRepository>();
            // Services
            builder.Services.AddScoped<IHomeService, HomeService>();
            builder.Services.AddScoped<IRoomServices, RoomServices>();
            builder.Services.AddScoped<IAddressService, AddressService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddTransient<ErrorHandlingMiddleware>();    // exp builder
            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
            builder.Services.AddControllers();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateHomeRequestValidator>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var message = "";
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = ctx =>
                    {
                        message += "From OnAuthenticationFailed:\n";
                        message += FlattenException(ctx.Exception);
                        return Task.CompletedTask;
                    },
                    OnChallenge = ctx =>
                    {
                        message += "From OnChallenge:\n";
                        return Task.CompletedTask;

                    },
                    OnMessageReceived = ctx =>
                    {
                        message = "From OnMessageReceived:\n";
                        ctx.Request.Headers.TryGetValue("Authorization", out var BearerToken);
                        if (BearerToken.Count == 0)
                        {
                            BearerToken = "no Bearer token sent\n";
                        }

                        message += "Authorization Header sent: " + BearerToken + "\n";
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = ctx =>
                    {
                        Debug.WriteLine("token: " + ctx.SecurityToken.ToString());
                        return Task.CompletedTask;
                    }
                };

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                };

            });
            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }

        public static string FlattenException(Exception exception)
        {
            var stringBuilder = new StringBuilder();

            while (exception != null)
            {
                stringBuilder.AppendLine(exception.Message);
                stringBuilder.AppendLine(exception.StackTrace);

                exception = exception.InnerException;
            }
            return stringBuilder.ToString();
        }
    }
}