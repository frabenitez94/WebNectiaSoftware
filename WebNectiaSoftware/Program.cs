using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios para Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddAuthorization();

// Agregar servicios para controladores con vistas
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<AccountController>(client =>
{
    client.BaseAddress = new Uri("https://localhost:44385"); // Cambia esto por la URL de tu aplicación
});
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login"; // Ruta a tu acción de Login
    options.AccessDeniedPath = "/Account/AccessDenied"; // Ruta para acceso denegado si es necesario
});


var app = builder.Build();

// Configuración del pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Debe estar antes de UseAuthorization
app.UseAuthorization();


app.MapGroup("/identity").MapIdentityApi<IdentityUser>();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
