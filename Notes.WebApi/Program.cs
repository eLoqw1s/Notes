using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Notes.Application.ExternalLogic;
using Notes.Application.Interfaces;
using Notes.Application.Interfaces.Auth;
using Notes.Application.Services;
using Notes.Persistence;
using Notes.Persistence.Repositories;
using Notes.WebApi.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.AddApiAuthentication(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NotesDbContext>(
    options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString(nameof(NotesDbContext)));
    }
);

builder.Services.AddScoped<INotesService, NotesService>();
builder.Services.AddScoped<INotesRepository, NotesRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

builder.Services.AddScoped < UsersService>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
