using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Net.Http.Headers;
using ProjectHub.Abstractions.IMappers.ProgrammingLanguages;
using ProjectHub.Abstractions.IMappers.Project;
using ProjectHub.Abstractions.IMappers.Tribe;
using ProjectHub.Abstractions.IMappers.User;
using ProjectHub.Abstractions.IService.ProgrammingLanguage;
using ProjectHub.Abstractions.IService.Project;
using ProjectHub.Abstractions.IService.Tribe;
using ProjectHub.Abstractions.IValidation;
using ProjectHub.Api.MiddleWares;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Abstractions.IRepositories;
using ProjectHub.Data.Contexts;
using ProjectHub.Data.Repositories;
using ProjectHub.Mappers.ProgrammingLanguages;
using ProjectHub.Mappers.Project;
using ProjectHub.Mappers.Tribes;
using ProjectHub.Mappers.User;
using ProjectHub.Services.ProgrammingLanguage;
using ProjectHub.Services.Project;
using ProjectHub.Services.Tribe;
using ProjectHub.Validation;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<GlobalExceptionHandlerMiddleware>();

builder.Services.AddScoped<IProjectDtoMapper, ProjectDtoMapper>();
builder.Services.AddScoped<IProjectMapper, ProjectMapper>();
builder.Services.AddScoped<ITribeDtoMapper, TribeDtoMapper>();
builder.Services.AddScoped<IProgrammingLanguagesDtoMapper, ProgrammingLanguagesDtoMapper>();
builder.Services.AddScoped<IUserMapper, UserMapper>();

builder.Services.AddScoped<IGenericRepository<Project>, ProjectRepository>();
builder.Services.AddScoped<IGenericRepository<Tribe>, TribeRepository>();
builder.Services.AddScoped<IGenericRepository<ProgrammingLanguage>, ProgrammingLanguageRepository>();
builder.Services.AddScoped<IGenericRepository<User>, UserRepository>();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITribeService, TribeService>();
builder.Services.AddScoped<IProgrammingLanguageService, ProgrammingLanguageService>();

builder.Services.AddScoped<IProjectCreateDtoValidator, ProjectCreateCreateDtoValidator>();

builder.Services.AddDbContext<ProjectHubSqLiteDbContext>(options
    => options.UseSqlite(builder.Configuration
        .GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (IServiceScope scope = app.Services.CreateScope())
{
    ProjectHubSqLiteDbContext dbContext = scope.ServiceProvider.GetRequiredService<ProjectHubSqLiteDbContext>();
    dbContext.Database.Migrate();
}

app.UseCors(policy => policy.WithOrigins("https://localhost:7059", "http://localhost:5277").AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType));

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.MapControllers();

app.Run();