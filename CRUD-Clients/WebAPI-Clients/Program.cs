using Microsoft.EntityFrameworkCore;
using DBContext;
using WebAPI_Clients.Services.Interfaces;
using WebAPI_Clients.Services;
using WebAPI_Clients.Repository.Interfaces;
using WebAPI_Clients.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ClientsDbContext>(options => {
    options.UseSqlite("Data Source=Clients.db");
});
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Logging.AddConsole();
builder.Logging.AddDebug();

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
