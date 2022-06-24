
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((cxt, cfg) =>
    {
        cfg.Host("amqps://rfijyxzp:4v8P36gmWbM36lkKsJ5Gw0Fm36gplV_d@woodpecker.rmq.cloudamqp.com/rfijyxzp");
    });
});

builder.Services.AddMassTransitHostedService();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();


app.Run();
