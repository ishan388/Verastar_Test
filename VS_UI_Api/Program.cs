using Microsoft.EntityFrameworkCore;
using VS_DLRepositories;
using VS_UI_Api;

var CorsPolicy = "MyPolicy";
var builder = WebApplication.CreateBuilder(args);

//CORS setting
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy,
        builder =>
        {
            builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Add services to the container.

IoCSetup.Configure(builder);
builder.Services.AddDbContext<MyShopContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(CorsPolicy);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
