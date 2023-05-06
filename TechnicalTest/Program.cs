using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using TechnicalTest.Attributes;
using TechnicalTest.Data;
using TechnicalTest.Repositories;
using TechnicalTest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options => { options.InvalidModelStateResponseFactory = ModelStateValidator.ValidModelState; }); ;

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "WebSitesPolicy", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddScoped<DapperContext>();
builder.Services.AddScoped<IDapperService,DapperService>();
builder.Services.AddScoped<IVacancyRepository,VacancyRepository>();
builder.Services.AddScoped<IProspectRepository,ProspectRepository>();
builder.Services.AddScoped<IInterviewRepository,InterviewRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("Interviews", new OpenApiInfo
    {
        Title = "Interviews Controller",
        Version = "v1",
        Description = "Web service to manage the entity's crud operations Interview",
        Contact = new OpenApiContact
        {
            Name = "Jaime Tenorio",
            Email = "jaimetenoriorios@outlook.com",
        },
        License = new OpenApiLicense
        {
            Name = "Use inder license ###",
        }
    });

    c.SwaggerDoc("Vacancies", new OpenApiInfo
    {
        Title = "Vacancies Controller",
        Version = "v1",
        Description = "Web service to manage the entity's crud operations Vacancie",
        Contact = new OpenApiContact
        {
            Name = "Jaime Tenorio",
            Email = "jaimetenoriorios@outlook.com",
        },
        License = new OpenApiLicense
        {
            Name = "Use inder license ###",
        }
    });

    c.SwaggerDoc("Prospects", new OpenApiInfo
    {
        Title = "Prospects Controller",
        Version = "v1",
        Description = "Web service to manage the entity's crud operations Prospect",
        Contact = new OpenApiContact
        {
            Name = "Jaime Tenorio",
            Email = "jaimetenoriorios@outlook.com",
        },
        License = new OpenApiLicense
        {
            Name = "Use inder license ###",
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c => c.RouteTemplate = "/swagger/{documentname}/swagger.json");

    app.UseSwaggerUI(c =>
    {
        c.ConfigObject = new ConfigObject
        {
            ShowCommonExtensions = true
        };

        c.RoutePrefix = "swagger";
        c.InjectStylesheet("/swagger-ui/custom.css");
        c.InjectJavascript("/swagger-ui/custom.js");
        c.SwaggerEndpoint("Interviews/swagger.json", "Interviews");
        c.SwaggerEndpoint("Vacancies/swagger.json", "Vacancies");
        c.SwaggerEndpoint("Prospects/swagger.json", "Prospects");
    });
}
else
{
    app.UseSwagger(c => c.RouteTemplate = "/TestDocumentation/{documentname}/swagger.json");

    app.UseSwaggerUI(c =>
    {
        c.ConfigObject = new ConfigObject
        {
            ShowCommonExtensions = true
        };

        c.RoutePrefix = "TestDocumentation";
        c.InjectStylesheet("/swagger-ui/custom.css");
        c.InjectJavascript("/swagger-ui/custom.js");
        c.SwaggerEndpoint("Interviews/swagger.json", "Interviews");
        c.SwaggerEndpoint("Vacancies/swagger.json", "Vacancies");
        c.SwaggerEndpoint("Prospects/swagger.json", "Prospects");
    });
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.UseCors("WebSitesPolicy");

app.MapControllers();

app.Run();
