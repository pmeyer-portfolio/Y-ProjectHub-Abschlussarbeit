using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjectHub.Blazor;
using ProjectHub.Blazor.Initializer;
using ProjectHub.Blazor.Mappers;
using ProjectHub.Blazor.Services;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Contracts;
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

builder.Services.AddScoped<ITribeService, TribeService>();
builder.Services.AddScoped<IProgrammingLanguageService, ProgrammingLanguageService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectFilterService, ProjectFilterService>();
builder.Services.AddScoped<IProjectViewModelMapper, ProjectViewModelMapper>();
builder.Services.AddScoped<IDropDownDataGridInitializer, DropDownDataGridInitializer>();
builder.Services.AddScoped<IProjectDetailsViewModelMapper, ProjectDetailsViewModelMapper>();
builder.Services.AddScoped<IProjectUpdateDtoMapper, ProjectUpdateDtoMapper>();
builder.Services.AddScoped<IProjectUpdateService, ProjectUpdateService>();
builder.Services.AddScoped<IProjectDetailsService, ProjectDetailsService>();
builder.Services.AddRadzenComponents();
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.LoginMode = "popup";
});

await builder.Build().RunAsync();