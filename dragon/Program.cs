using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using dragon.Data;
using Microsoft.AspNetCore.Identity;
using dragon.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<dragonContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dragonContext") ?? throw new InvalidOperationException("Connection string 'dragonContext' not found.")));

//builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<dragonContext>();

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Stores.MaxLengthForKeys = 128;
})
    .AddEntityFrameworkStores<dragonContext>()
    .AddRoles<IdentityRole>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<dragonContext>();
    var userMgr = services.GetRequiredService<UserManager<AppUser>>();
    var roleMgr = services.GetRequiredService<RoleManager<IdentityRole>>();
    IdentitySeedData.Initialize(context, userMgr, roleMgr).Wait();
}

app.Run();
