using IdentityAndAuth.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//adding conn string
var connectionString = builder.Configuration["ConnectionStrings:Default"];
builder.Services.AddDbContext<ApplicationDbContext>(o=>o.UseSqlServer(connectionString));
//adding identity
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

//cookie based auth
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true; 
    options.Password.RequireDigit=true; 
    options.Password.RequireLowercase = true; 
    options.Password.RequireUppercase = true;
    options.SignIn.RequireConfirmedEmail = true;

});

//to enable coikie based auth

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Home/Signin";
    options.AccessDeniedPath = "/Home/AccessDeniedPath";

});

// Add services to the container.
builder.Services.AddControllersWithViews();

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
