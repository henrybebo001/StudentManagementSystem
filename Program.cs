
using Supabase.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Get Supabase configuration.
var supabaseUrl = builder.Configuration["Supabase:Url"];
var supabaseKey = builder.Configuration["Supabase:Key"];

// Validate Supabase URL.
if (string.IsNullOrWhiteSpace(supabaseUrl))
{
    throw new InvalidOperationException(
        "Supabase URL is not configured."
    );
}

// Validate Supabase API Key.
if (string.IsNullOrWhiteSpace(supabaseKey))
{
    throw new InvalidOperationException(
        "Supabase API key is not configured."
    );
}

// Validate URL format and HTTPS protocol.
if (!Uri.TryCreate(supabaseUrl, UriKind.Absolute, out var uri) ||
    uri.Scheme != Uri.UriSchemeHttps)
{
    throw new InvalidOperationException(
        "Supabase URL must be a valid HTTPS URL."
    );
}

// Register Supabase client.
builder.Services.AddSupabase(
    supabaseUrl: supabaseUrl,
    supabaseKey: supabaseKey
);

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
