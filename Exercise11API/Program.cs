using Exercise11API.Data;
using Exercise11API.Services;
using Microsoft.EntityFrameworkCore;

namespace Exercise11API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        //builder.Services.AddScoped<IAzureStorageService, StorageService>();
        builder.Services.AddDbContext<PropertyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDefaultConnection")));
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddTransient<IStorageService, StorageService>();

        //builder.Services.AddDbContext<PropertyDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:LocalDefaultConnection"]));

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

        DbInitializer.Seed(app);

        app.Run();
    }
}
