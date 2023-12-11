using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjectHub.Blazor;
using ProjectHub.Blazor.Services;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Contracts;
using Radzen;

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("ProjectHubClient");
builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
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
builder.Services.AddRadzenComponents();
builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.LoginMode = "popup";
});

await builder.Build().RunAsync();