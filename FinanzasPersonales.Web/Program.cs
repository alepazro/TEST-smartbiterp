using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FinanzasPersonales.Infrastructure.Data;
using FinanzasPersonales.Application.Services;
using FinanzasPersonales.Application.Interfaces;
using FinanzasPersonales.Core.Interfaces;
using FinanzasPersonales.Infrastructure.Repositories;
using FinanzasPersonales.Application.Mappings;

// Agrega este using

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowUI", policy =>
    {
        policy.WithOrigins("https://localhost:7124") // Cambia al puerto real de tu UI
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

//  Connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

//  DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//  Repositories
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ITipoGastoRepository, TipoGastoRepository>();
builder.Services.AddScoped<IRegistroGastoRepository, RegistroGastoRepository>();
builder.Services.AddScoped<IPresupuestoRepository, PresupuestoRepository>();
builder.Services.AddScoped<IFondoMonetarioRepository, FondoMonetarioRepository>();
builder.Services.AddScoped<IDetalleGastoRepository, DetalleGastoRepository>();
builder.Services.AddScoped<IDepositoRepository, DepositoRepository>();

//  Application Services
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ITipoGastoService, TipoGastoService>();
builder.Services.AddScoped<IRegistroGastoService, RegistroGastoService>();
builder.Services.AddScoped<IPresupuestoService, PresupuestoService>();
builder.Services.AddScoped<IFondoMonetarioService, FondoMonetarioService>();
builder.Services.AddScoped<IDetalleGastoService, DetalleGastoService>();
builder.Services.AddScoped<IDepositoService, DepositoService>();

//  AutoMapper
builder.Services.AddAutoMapper(typeof(UsuarioProfile).Assembly);
builder.Services.AddAutoMapper(typeof(TipoGastoProfile).Assembly);
builder.Services.AddAutoMapper(typeof(RegistroGastoProfile).Assembly);
builder.Services.AddAutoMapper(typeof(PresupuestoProfile).Assembly);
builder.Services.AddAutoMapper(typeof(FondoMonetarioProfile).Assembly);
builder.Services.AddAutoMapper(typeof(DetalleGastoProfile).Assembly);
builder.Services.AddAutoMapper(typeof(DepositoProfile).Assembly);

//  Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();



// MVC + Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Finanzas Personales API",
        Version = "v1"
    });
});

// ==================== APP ====================

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Finanzas Personales API v1");
        c.RoutePrefix = string.Empty;
    });
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();
app.UseCors("AllowUI");

app.UseAuthorization();

// Mapea controladores
app.MapControllers();
app.MapRazorPages(); // si usas Identity UI

// Si también usas vistas MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
