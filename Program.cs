using Application_06.Components;
using Application_06.Models;
using Application_06.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register configuration and notification services
builder.Services.AddSingleton<NotificationConfig>();
builder.Services.AddScoped<NotificationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// CHANGED: Removed the specific namespace prefix so it dynamically resolves the App component 
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();