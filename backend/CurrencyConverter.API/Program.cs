using CurrencyConverter.API.Services;
using CurrencyConverter.API.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure MongoDB settings
var mongoDbSettings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>() 
    ?? throw new InvalidOperationException("MongoDbSettings not configured");
builder.Services.AddSingleton(mongoDbSettings);

// Configure Fixer API settings
var fixerApiSettings = builder.Configuration.GetSection("FixerApiSettings").Get<FixerApiSettings>()
    ?? throw new InvalidOperationException("FixerApiSettings not configured");
builder.Services.AddSingleton(fixerApiSettings);

// Register services
builder.Services.AddSingleton<IMongoDbService, MongoDbService>();
builder.Services.AddHttpClient<IFixerApiService, FixerApiService>();
builder.Services.AddScoped<ICurrencyConversionService, CurrencyConversionService>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
