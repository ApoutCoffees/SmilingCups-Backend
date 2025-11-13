using Microsoft.EntityFrameworkCore;
using SmilingCup_Backend.profiles.application.Internal.commandservices;
using SmilingCup_Backend.profiles.application.Internal.queryservices;
using SmilingCup_Backend.profiles.domain.repositories;
using SmilingCup_Backend.profiles.domain.services;
using SmilingCup_Backend.profiles.infrastructure.persistence.efc.repositories;
using SmilingCup_Backend.Shared.domain.repositories;
using SmilingCup_Backend.Shared.Infrastructure.Interfaces.Asp.Configuration;
using SmilingCup_Backend.Shared.infrastructure.persistence.efc.configuration;
using SmilingCup_Backend.Shared.infrastructure.persistence.efc.repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();


// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

if (connectionString == null) throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
});


// Dependency Injection

// Shared Bounded Context
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Profiles Bounded Context Dependency Injection Configuration
builder.Services.AddScoped<IMonthlySaleRepository, MonthlySaleRepository>();
builder.Services.AddScoped<IMonthlySaleCommandService, MonthlySaleCommandService>();
builder.Services.AddScoped<IMonthlySaleQueryService, MonthlySaleQueryService>();

builder.Services.AddScoped<IProducerStatRepository, ProducerStatRepository>();
builder.Services.AddScoped<IProducerStatCommandService, ProducerStatCommandService>();
builder.Services.AddScoped<IProducerStatQueryService, ProducerStatQueryService>();

builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<IFavoriteCommandService, FavoriteCommandService>();
builder.Services.AddScoped<IFavoriteQueryService, FavoriteQueryService>();



var app = builder.Build();


// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS Policy
app.UseCors("AllowAllPolicy");


// Add Authorization Middleware to Pipeline
//app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();