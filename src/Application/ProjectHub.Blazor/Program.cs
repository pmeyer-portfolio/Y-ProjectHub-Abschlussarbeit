using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjectHub.Blazor;
using ProjectHub.Blazor.Initializer;
using ProjectHub.Blazor.Interfaces;
using ProjectHub.Blazor.Mappers.ProgrammingLanguage;
using ProjectHub.Blazor.Mappers.Project;
using ProjectHub.Blazor.Mappers.Project.Interfaces;
using ProjectHub.Blazor.Mappers.Tribe;
using ProjectHub.Blazor.Services;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.ProgrammingLanguage;
using ProjectHub.Blazor.Services.Project;
using ProjectHub.Blazor.Services.Project.Interfaces;
using ProjectHub.Blazor.Services.Tribe;
using Radzen;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("ProjectHubClient");
builder.Services.AddScoped<IProjectHubApiClient, ProjectHubApiClient>(x =>
    {
        IHttpClientFactory factory = x.GetRequiredService<IHttpClientFactory>();
        HttpClient httpClient = factory.CreateClient("ProjectHubClient");

        ProjectHubApiClient projectHubClient = new("https://localhost:7187", httpClient);
        return projectHubClient;
    }
);
builder.Services.AddScoped<IProjectDetailsViewModelMapper, ProjectDetailsViewModelMapper>();
builder.Services.AddScoped<IProjectViewModelMapper, ProjectViewModelMapper>();
builder.Services.AddScoped<IProjectUpdateDtoMapper, ProjectUpdateDtoMapper>();
builder.Services.AddScoped<ITribeViewModelMapper, TribeViewModelMapper>();
builder.Services.AddScoped<IProgrammingLanguageViewModelMapper, ProgrammingLanguageViewModelMapper>();

builder.Services.AddScoped<ITribeService, TribeService>();
builder.Services.AddScoped<IProgrammingLanguageService, ProgrammingLanguageService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectFilterService, ProjectFilterService>();
builder.Services.AddScoped<IProjectUpdateService, ProjectUpdateService>();
builder.Services.AddScoped<INotificationServiceWrapper, NotificationServiceWrapperWrapper>();

builder.Services.AddScoped<IProjectHubDataInitializer, ProjectHubDataInitializer>();
builder.Services.AddScoped<IEditDialogInitializer, EditDialogInitializer>();

builder.Services.AddScoped<NotificationService>();

builder.Services.AddRadzenComponents();
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.LoginMode = "popup";
});

await builder.Build().RunAsync();