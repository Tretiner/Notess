using Microsoft.EntityFrameworkCore;
using Notess.Components;
using Notess.Data;
using Notess.Services;

var builder = WebApplication.CreateBuilder(args);

var dbFilePath = Path.Combine("Data", "Storage", "app.db");
builder.Services.AddDbContext<AppDbContext>(s =>
{
    s.UseSqlite($"Data Source={dbFilePath}");
    s.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<TodoService>();

builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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