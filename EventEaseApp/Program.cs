using EventEaseApp.Components;
using EventEaseApp.Logging; // Add this using statement

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add HttpContextAccessor service
builder.Services.AddHttpContextAccessor();

// Add session services
builder.Services.AddDistributedMemoryCache(); // Use in-memory cache for session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // You can configure the session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true; // Make the cookie essential
});

// Register LoggingService
builder.Services.AddSingleton<ILoggingService, LoggingService>();

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

app.UseRouting(); // Make sure routing is enabled

app.UseAntiforgery();

// Add session middleware
app.UseSession();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
