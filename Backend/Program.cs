using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Backend.Domain.Models.Usuarios;
using Backend.Domain.Interfaces;
using Backend.Infrastructure.Data.Repositories;
using Backend.Application.Interfaces;
using Backend.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<INotaService, NotaService>();
builder.Services.AddScoped<INotaRepository, NotaRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
