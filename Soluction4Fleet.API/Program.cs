using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Soluction4Fleet.API.Domain.Data;
using Soluction4Fleet.API.Presentation.Extensions;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ----------------------
// Configuração do banco
// ----------------------
var connectionStringPadrao = builder.Configuration.GetConnectionString("ConexaoPadrao");

builder.Services.AddDbContext<Soluction4FleetContext>(options =>
    options.UseSqlServer(connectionStringPadrao));


// ----------------------
// CORS
// ----------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policy => policy
            .WithOrigins(
                "http://localhost:3000", // URL do frontend em desenvolvimento
                "http://localhost:5181",
                "https://localhost:7064"
              ) // URL real do frontend
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});


// ----------------------
// Controllers
// ----------------------
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );


// ----------------------
// JWT Authentication
// ----------------------
var jwtKey = builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("Chave JWT não configurada");
var key = Encoding.UTF8.GetBytes(jwtKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = !builder.Environment.IsDevelopment();
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateLifetime = true
    };
});

// ----------------------
// Swagger / OpenAPI 3.0
// ----------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Locadora",
        Version = "v1",
        Description = "API para o sistema locadora"
    });

    // JWT Bearer
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Insira o token JWT no formato: Bearer {token}",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, Array.Empty<string>() }
    });

    // Evitar problemas de nomes internos (ex: nested classes)
    c.CustomSchemaIds(x => x.FullName?.Replace("+", "."));
});

// ----------------------
// Outros serviços da aplicação
// ----------------------
builder.Services.AddApplicationServices(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Locadora v1");
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthentication();
//app.UseMiddleware<AuthenticationLoggingMiddleware>();
app.UseAuthorization();
//app.UseLogMiddleware();
//app.UseMiddleware<ExceptionMiddleware>(); // AQUI
//app.UseSerilogRequestLogging();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<Soluction4FleetContext>();
    db.Database.Migrate();
}
app.Run();
