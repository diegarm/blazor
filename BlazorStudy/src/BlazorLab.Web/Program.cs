using BlazorLab.Web.Components;
using BlazorLab.Infrastructure.Data;
using BlazorLab.Infrastructure.Repositories;
using BlazorLab.Infrastructure.Services;
using BlazorLab.Application.Interfaces;
using BlazorLab.Application.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configurar Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configurar banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=blazorlab.db"));

// Registrar serviços - Padrão Repository e Injeção de Dependências
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddScoped<BlazorLab.Web.Services.UserState>();

builder.Services.AddTransient<BlazorLab.Web.Services.AuthLoggingHandler>();
builder.Services.AddHttpClient<BlazorLab.Web.Services.IUserApi, BlazorLab.Web.Services.UserApi>(c =>
    {
        c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        c.Timeout = TimeSpan.FromSeconds(10);
    })
    .AddHttpMessageHandler<BlazorLab.Web.Services.AuthLoggingHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
