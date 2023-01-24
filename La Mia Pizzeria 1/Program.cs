using Microsoft.AspNetCore.Identity;

using La_Mia_Pizzeria_1.Database;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PizzeriaContext>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<PizzeriaContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

// Aggiungo una nuova configurazione per la mia app in modo che possa abilitare
// l'autenticazione per i miei controller e metodi
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
