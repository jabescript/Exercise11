using Exercise11API.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercise11API.Data;

public class PropertyDbContext : DbContext
{
    public PropertyDbContext()
    {

    }
    public PropertyDbContext(DbContextOptions<PropertyDbContext> options)
        : base(options)
    {

    }

    public DbSet<PropertyModel> Properties { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    IConfigurationRoot configuration = new ConfigurationBuilder()
    //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    //        .AddJsonFile("appsettings.json")
    //        .Build();
    //    optionsBuilder.UseSqlServer(configuration["ConnectionStrings:LocalDefaultConnection"]);
    //}
}
