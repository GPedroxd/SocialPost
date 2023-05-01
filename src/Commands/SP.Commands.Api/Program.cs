using Confluent.Kafka;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using SP.Commands.Application.Handlers;
using SP.Commands.Domain.Aggregates.PostAggregate;
using SP.Commands.Infra.Config;
using SP.Commands.Infra.Handlers;
using SP.Commands.Infra.Producers;
using SP.Commands.Infra.Repositories;
using SP.Commands.Infra.Store;
using SP.Core.Events;
using SP.Core.Handlers;
using SP.Core.Infra;
using SP.Core.Producers;

var builder = WebApplication.CreateBuilder(args);

//difine how will be serialize guids atributtes, in this case will be as string
BsonSerializer.RegisterSerializer(typeof(Guid), new GuidSerializer(MongoDB.Bson.BsonType.String));

// Add services to the container.
builder.Services.AddScoped<IEventStore, EventStore>();
builder.Services.AddScoped<IEventProducer, EventProducer>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventSourcingHandler<PostAggregate>, EventSourcingHandler>();
builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection(nameof(MongoDbConfig)));
builder.Services.Configure<ProducerConfig>(builder.Configuration.GetSection(nameof(ProducerConfig)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(m => m.RegisterServicesFromAssemblyContaining<MediatRAssembly>());

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
