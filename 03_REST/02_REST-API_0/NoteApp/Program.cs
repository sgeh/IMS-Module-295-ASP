#region Register DI dependencies

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

// TODO: Add Controllers Services
// TODO: Add CORS Services

#endregion


#region Application Startup

var app = builder.Build();

// Add for cshtml page mappings
app.MapRazorPages();
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

// TODO: Map Controllers Middleware
// TODO: Use CORS Middleware

// startup server
app.Run();

#endregion
