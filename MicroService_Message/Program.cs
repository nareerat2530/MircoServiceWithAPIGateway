
using MicroService_Message.Interfaces;
using MicroService_Message.Models;
using MicroService_Message.Repository;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);



builder.Services.Configure<MessageDatabaseSettings>(
    builder.Configuration.GetSection("MessageStoreDatabase"));
builder.Services.AddSingleton<IMessageRepository, MessageRepository>();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
