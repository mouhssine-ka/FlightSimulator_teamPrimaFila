using System.Reflection;
using System.Text.Json.Serialization;
using CompanyService.Configs;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using CompanyService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddDbContext<FlightSimulatorDBContext>(
    options => options.UseSqlServer("name=ConnectionStrings:FlightSimulatorDB")
    .EnableDetailedErrors()
    .EnableSensitiveDataLogging()
);

// Versioning Swagger
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddTransient<Microsoft.Extensions.Options.IConfigureOptions<Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    }
);

// Registro il database service
builder.Services.AddScoped<IDatabaseService, EFDatabase>();
builder.Services.AddScoped<IConversionService, ConversionService>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<FlightSimulatorDBContext>();
db.Database.EnsureDeleted();
db.Database.Migrate();

// simulazione seed db


Flotta f1 = Flotta.FlottaFactory("Flotta 1");
db.Flotte.Add(f1);
Flotta f2 = Flotta.FlottaFactory("Flotta 2");
db.Flotte.Add(f2);
db.SaveChanges();

Aereo a1 = new Aereo(f1.FlottaId,"AAAABBB", "Verde", 100);
db.Aerei.Add(a1); 
Aereo a2 = new Aereo(f2.FlottaId,"CCCDDD", "Giallo", 80);
db.Aerei.Add(a2); 
Aereo a3 = new Aereo(f2.FlottaId,"EEEFFF", "Rosa", 80);
db.Aerei.Add(a3); 
db.SaveChanges();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
app.UseSwagger(options => options.PreSerializeFilters.Add((swagger, req) => swagger.Servers = new List<OpenApiServer>() { new OpenApiServer() { Url = $"http://{req.Host}" } }));
app.UseSwaggerUI(options =>
{
    foreach (var desc in apiVersionDescriptionProvider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"../swagger/{desc.GroupName}/swagger.json", desc.ApiVersion.ToString());
        options.DefaultModelsExpandDepth(-1);
        options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    }
});

app.MapControllers();

app.Run();

