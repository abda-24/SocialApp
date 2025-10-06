using Domain.Entities;
using Domain.Interfaces;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Presentation.Hubs;
using Presistance;
using Presistance.Data.Repositorys;
using ServiceAbstraction;
using Services.MappingProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnection"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IDataSeeding, DataSeed>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSignalR();

// Configure Mapster
var config = TypeAdapterConfig.GlobalSettings;
config.Scan(typeof(Program).Assembly);

// Register Mapster
builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

builder.Services.AddScoped<IServiceManger, ServiceManger>();

var app = builder.Build();
var Scope = app.Services.CreateScope();
var objectOfDataSeeding = Scope.ServiceProvider.GetRequiredService<IDataSeeding>();
objectOfDataSeeding.DataSeed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseRouting();
app.MapHub<ChatHub>("/hubs/chat");
app.MapHub<NotificationHub>("/notificationHub");

app.Run();
