using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using AMInfra;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbContext,AMcontext>();
//instanciation des patrons
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<Type>(p=>typeof(GenericRepository<>));
//instaciation service
builder.Services.AddScoped<IServiceFlight,ServiceFlight>();
//=> iserviceflight sf= new serviceflight;
builder.Services.AddScoped<IservicePlane,ServicePlane >();

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

app.Run();
