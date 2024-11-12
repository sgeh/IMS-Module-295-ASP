#region Register DI dependencies

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NoteApp.Controllers;
using NoteApp.Data;
using NoteApp.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddDbContext<NoteAppContext>(opt =>
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
            .Replace("[Path]", builder.Environment.ContentRootPath)));

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

// Add for JWT mappings
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = JwtConfiguration.ValidIssuer,
            ValidAudience = JwtConfiguration.ValidAudience,
            IssuerSigningKey = new SymmetricSecurityKey(
               Encoding.UTF8.GetBytes(JwtConfiguration.IssuerSigningKey)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });


#endregion


#region Application Startup

var app = builder.Build();

// Add for JWT authorization (middleware)
app.UseAuthentication();
app.UseAuthorization();

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
