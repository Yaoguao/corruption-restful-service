using Corruption.Application.Service;
using Corruption.Core.Interfaces;
using Corruption.DataAccess;
using Corruption.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<CorruptionContext>();

builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<ICorruptionMessageService, CorruptionMessageService>();
builder.Services.AddScoped<ICorruptionMessageRepository, CorruptionMessageRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();

