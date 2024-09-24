var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

// register Server Session Management Services
builder.Services.AddSession();

var app = builder.Build();
app.UseStaticFiles();

// activate Server Session Management
app.UseSession();

app.MapRazorPages();
//app.MapGet("/", () => "Hello World!");
app.Run();
