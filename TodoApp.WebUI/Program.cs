using Microsoft.EntityFrameworkCore;
using TodoApp.Business.Interfaces;
using TodoApp.Business.Services;
using TodoApp.DataAccess.Context;
using TodoApp.DataAccess.Interfaces;
using TodoApp.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Sql server baðlantýsý
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Repository ve Service DI
builder.Services.AddScoped<ITaskItemRepository,TaskItemRepository>();
builder.Services.AddScoped<ITaskItemService,TaskItemService>();

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
    pattern: "{controller=TaskItem}/{action=Index}/{id?}");

app.Run();
