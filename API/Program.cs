using DataAccess.Mediators;
using DataAccess.Providers;
using MartinDueAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRelationalDatabaseProvider, MySqlProvider>();
builder.Services.AddSingleton<IMediator, PetMediator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureApi();

app.Run();