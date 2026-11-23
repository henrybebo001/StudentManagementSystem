
using Supabase.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Registrar controladores
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar el cliente de Supabase
builder.Services.AddSupabase(
    supabaseUrl: builder.Configuration["Supabase:Url"]!,
    supabaseKey: builder.Configuration["Supabase:Key"]!
);

// Configurar autorización
builder.Services.AddAuthorization();

var app = builder.Build();

// Configurar Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
