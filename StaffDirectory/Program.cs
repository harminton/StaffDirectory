using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StaffDirectory.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("StaffContextConnection") ?? throw new InvalidOperationException("Connection string 'StaffContextConnection' not found.");

builder.Services.AddDbContext<StaffContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<StaffUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<StaffContext>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
