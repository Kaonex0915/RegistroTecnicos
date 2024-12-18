using Microsoft.EntityFrameworkCore;
using Radzen;
using RegistroTecnicos.Components;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContextFactory<Context>(Options => Options.UseSqlServer(ConStr));
builder.Services.AddScoped<TecnicoServices>();
builder.Services.AddScoped<TipoTecnicosServices>();
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<ClientesServices>();
builder.Services.AddScoped<TrabajoServices>();
builder.Services.AddScoped<PrioridadesServices>();
builder.Services.AddScoped<CotizacionServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
