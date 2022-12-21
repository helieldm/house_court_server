using HouseCourt.Context;
using HouseCourt.Helper;
using HouseCourt.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<HouseCourtContext>();
builder.Services.AddScoped<MessageService>();
builder.Services.AddScoped<HouseService>();
builder.Services.AddScoped<ReadingService>();
builder.Services.AddScoped<WebSocketService>();
builder.Services.AddScoped<TaskService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2)
};

app.UseWebSockets(webSocketOptions);

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();