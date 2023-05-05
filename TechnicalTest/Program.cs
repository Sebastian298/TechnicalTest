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

app.UseCors("WebSitesPolicy");

app.MapControllers();

app.Run();
