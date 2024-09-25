using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using shopsincampus.business;
using shopsincampus.business.Interfaces;
using shopsincampus.business.Services;
using shopsincampus.data.Interfaces;
using shopsincampus.data.Repositories;

public class Startup
{
    public void ConfigureServices(IServiceCollection services) {

        services.AddSingleton<IMongoClient>(sp => new MongoClient("mongodb+srv://akshibellare:Sp2nFgw2RH4IEsU2@shopsincampus.agypt.mongodb.net/?retryWrites=true&w=majority&appName=shopsincampus"));
        
        services.AddScoped<IMongoDatabase>(sp => 
            sp.GetRequiredService<IMongoClient>().GetDatabase("shopsincampus"));
        services.AddScoped<IDomainModelRepository, DomainModelRepository>();
        services.AddScoped<IShopRepository, ShopRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IShopManager, ShopManager>();
        services.AddScoped<IAuthManager, AuthManager>();

        services.AddAuthorization();

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
             c.RoutePrefix = string.Empty; // Set to empty string to serve the UI at the root
        });
        app.UseAuthorization();
        app.UseEndpoints(endPoints => {endPoints.MapControllers();});
    }
}
