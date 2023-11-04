using System.Diagnostics;
using DummyApi.Logging;
using Serilog;
var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.Configure(options =>
    {
        options.ActivityTrackingOptions = ActivityTrackingOptions.TraceId | ActivityTrackingOptions.SpanId;
    });
}).UseSerilog(SeriLogger.Configure);
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
