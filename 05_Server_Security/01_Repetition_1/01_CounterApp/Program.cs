using Bwz.Rappi.Data;
using Bwz.Rappi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddDbContext<CounterAppContext>(opt => 
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
            .Replace("[Path]", builder.Environment.ContentRootPath)));

builder.Services.AddTransient<DbInitializer>();

// needed for API access through the API client; see UseCors()
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS_CONFIG", cors =>
    {
        cors.WithMethods(builder.Configuration["Cors:Method"])
            .WithHeaders(builder.Configuration["Cors:Header"])
            .WithOrigins(builder.Configuration["Cors:Origin"]);
    });
});


var app = builder.Build();

// add -->
app.MapControllers();
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = (context) =>
    {
        // Disable caching of all static files.
        context.Context.Response.Headers["Cache-Control"] = builder.Configuration["StaticFiles:CacheControl"];
        context.Context.Response.Headers["Pragma"] = builder.Configuration["StaticFiles:Pragma"];
        context.Context.Response.Headers["Expires"] = builder.Configuration["StaticFiles:Expires"];
    }
});
app.MapRazorPages();
app.UseCors("CORS_CONFIG");
// <--

using (var scope = app.Services.CreateScope()) // oberhalb von app.Run()
{
    // Execute db initializer
    scope.ServiceProvider.GetRequiredService<DbInitializer>().Run();
}

app.Run();
