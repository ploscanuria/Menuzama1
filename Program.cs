using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Menuzama1.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});


// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/MenuItems");
    options.Conventions.AllowAnonymousToPage("/MenuItems/Index");
    options.Conventions.AllowAnonymousToPage("/MenuItems/Details");
    options.Conventions.AuthorizeFolder("/Clients", "AdminPolicy");
});
builder.Services.AddDbContext<Menuzama1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Menuzama1Context") ?? throw new InvalidOperationException("Connection string 'Menuzama1Context' not found.")));


builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Menuzama1Context") ?? throw new InvalidOperationException("Connectionstring 'Menuzama1Context' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()

 .AddEntityFrameworkStores<LibraryIdentityContext>();
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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
