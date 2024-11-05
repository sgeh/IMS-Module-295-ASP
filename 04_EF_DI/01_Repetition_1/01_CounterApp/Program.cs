using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllers();

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
app.UseHttpsRedirection();
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

app.Run();
