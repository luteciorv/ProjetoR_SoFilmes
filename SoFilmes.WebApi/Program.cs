using Microsoft.OpenApi.Models;
using SoFilmes.Application.Extensions;
using SoFilmes.Infrastructure.Persistence.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.ConfigureApplicationServices();
    builder.Services.ConfigurePersistenceServices(builder.Configuration);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(config =>
    {
        config.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "WebApi.SoFilmes",
            Version = "v1"
        });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        config.IncludeXmlComments(xmlPath);
    });
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}