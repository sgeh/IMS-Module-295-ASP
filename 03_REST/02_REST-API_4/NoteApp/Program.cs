#region Register DI dependencies

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllers();

// Needed for API access through the JS client; see UseCors()
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS_CONFIG", cors =>
    {
        cors.WithMethods(builder.Configuration["Cors:Method"])
            .WithHeaders(builder.Configuration["Cors:Header"])
            .WithOrigins(builder.Configuration["Cors:Origin"]);
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

// startup server
app.Run();

#endregion
