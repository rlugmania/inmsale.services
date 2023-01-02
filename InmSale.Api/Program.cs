using InmSale.Repositories;
using InmSale.Repositories.Commons;
using InmSale.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Create a geometry factory with the spatial reference id 4326 which represents spatial data using longitude and latitude 
// coordinates on the Earth's surface as defined in the WGS84 standard, which is also used for the Global Positioning System (GPS)
builder.Services.AddSingleton(NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326));

builder.Services.AddSingleton<IMongoClient>(new MongoClient("mongodb://127.0.0.1:27017"));
builder.Services.AddSingleton<IGenericDbRepository>(sp=> new GenericDbRepository(sp.GetRequiredService<IMongoClient>(), "application-api"));
builder.Services.AddSingleton<IProjectsRepository, ProjectsRepository>();
builder.Services.AddSingleton<IProjectAdministrationService, ProjectAdministrationService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
