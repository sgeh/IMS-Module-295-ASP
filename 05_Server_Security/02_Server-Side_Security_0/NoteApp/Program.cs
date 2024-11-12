#region Register DI dependencies

using Microsoft.EntityFrameworkCore;
using NoteApp.Data;
using NoteApp.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddDbContext<NoteAppContext>(opt =>
{
    var connString = builder.Configuration.GetConnectionString("DefaultConnection");
    var connStringWithContentRoot = connString.Replace("[Path]", builder.Environment.ContentRootPath);
    opt.UseSqlServer(connStringWithContentRoot);
});
builder.Services.AddTransient<DbInitializer>();

// Needed for API access through the JS client; see UseCors()
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS_CONFIG", cors =>
    {
        cors.WithMethods("*")
            .WithHeaders("*")
            .WithOrigins("*");
    });
});



#endregion


#region Application Startup

var app = builder.Build();

// Add for cshtml page mappings
app.MapRazorPages();
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

app.UseCors("CORS_CONFIG");

using (var scope = app.Services.CreateScope())
{
    // Execute db initializer
    scope.ServiceProvider.GetRequiredService<DbInitializer>().Run();
}

// startup server
app.Run();

#endregion
