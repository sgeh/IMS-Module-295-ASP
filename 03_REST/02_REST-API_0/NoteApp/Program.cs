#region Register DI dependencies

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

// TODO: Aufgabe 4) Add Controllers Services
// TODO: Aufgabe 6) Add CORS Services

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

// TODO: Aufgabe 4) Map Controllers Middleware
// TODO: Aufgabe 6) Use CORS Middleware

// startup server
app.Run();

#endregion
