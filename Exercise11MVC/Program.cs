using Azure.Storage.Blobs;
using Exercise11MVC.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(serviceProvider => new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=jabezstorageaccount;AccountKey=HQviFSzbWA3drdjoGcdIke+OcRtc8vO5stvg9+REzbsF3x8Py/cTdSYBaAZddb0m9nZVpQIq0wQq+AStvpeX2g==;EndpointSuffix=core.windows.net"));
builder.Services.AddTransient<IStorageService, StorageService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//DbInitializer.Seed(app);

app.Run();
