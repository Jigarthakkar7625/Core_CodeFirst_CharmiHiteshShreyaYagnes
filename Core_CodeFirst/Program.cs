//using Core_CodeFirst.Models;
using Core_CodeFirst;
using Core_CodeFirst.Data.Models;
using Core_CodeFirst.Services;
using Core_CodeFirst.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TestDbmajwtContext>(options =>
    options.UseSqlServer(connectionString));



// Dependancy Injection
//builder.Services.AddTransient<IEmployees, Employees>();

//builder.Services.AddTransient<ITransient, Employees>();
//builder.Services.AddScoped<IScoped, Employees>();
//builder.Services.AddSingleton<ISingleton, Employees>();



builder.Services.AddTransient<IEmployees, Employees>();
builder.Services.AddTransient<IEmployees, Employees123>();

builder.Services.AddSwaggerGen();
//// Dependancy Injection
//builder.Services.AddScoped<IEmployees, Employees>();

//// Dependancy Injection
//builder.Services.AddSingleton<IEmployees, Employees>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<Error>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Custom middleware
app.UseMiddleware<Error>();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
});
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
