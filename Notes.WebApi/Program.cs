using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Application.Services;
using Notes.Persistence;
using Notes.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
