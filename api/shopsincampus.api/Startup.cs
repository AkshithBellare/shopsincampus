using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using shopsincampus.business;
using shopsincampus.business.Interfaces;
using shopsincampus.business.Services;
using shopsincampus.data.Interfaces;
using shopsincampus.data.Models;
using shopsincampus.data.Repositories;

public class Startup
{
    public void ConfigureServices(IServiceCollection services) {

        services.AddSingleton<IMongoClient>(sp => new MongoClient("mongodb+srv://akshibellare:k8t05I46bvcH0eWg@shopsincampus.agypt.mongodb.net/?retryWrites=true&w=majority&appName=shopsincampus"));
        
        services.AddScoped<IMongoDatabase>(sp => 
            sp.GetRequiredService<IMongoClient>().GetDatabase("shopsincampus"));
        services.AddScoped<IDomainModelRepository<Shop>, DomainModelRepository<Shop>>();
        services.AddScoped<IShopRepository, ShopRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IShopManager, ShopManager>();
        services.AddScoped<IAuthManager, AuthManager>();

        services.AddAuthorization();

        var key = Encoding.ASCII.GetBytes("YourSecretKeyHere"); // Use a strong secret key
    services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false; // Set to true in production
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false, // Set to true in production
            ValidateAudience = false // Set to true in production
        };
    });

        services.AddControllers();

        services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Shop In Campus API", Version="v1"});
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        if(env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        }
        else {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseSwagger();

        app.UseSwaggerUI(c => {
             c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shops In Campus API V1");
             c.RoutePrefix = "swagger"; // Set to empty string to serve the UI at the root
        });
        app.UseAuthorization();
        app.UseEndpoints(endPoints => {endPoints.MapControllers();});
    }
}
