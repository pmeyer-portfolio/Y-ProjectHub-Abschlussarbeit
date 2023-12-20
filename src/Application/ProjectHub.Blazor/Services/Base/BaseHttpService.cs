namespace ProjectHub.Blazor.Services.Base;

using ProjectHub.Blazor.Models;

public class BaseHttpService
{
    protected IProjectHubApiClient apiClient;

    public BaseHttpService(IProjectHubApiClient apiClient)
    {
        this.apiClient = apiClient;
    }

    public Response<T> GetApiExceptionResponse<T>(ApiException<ProblemDetails> apiException)
    {
        return apiException switch
        {
            { StatusCode: 400 } => new Response<T>
            {
                Title = ResponseTitle.BadRequest,
                ValidationErrors = GetProblemDetails(apiException.Result),
                Success = false
            },
            { StatusCode: 403 } => new Response<T>
            {
                Title = ResponseTitle.ValidationError,
                ValidationErrors = GetProblemDetails(apiException.Result),
                Success = false
            },
            { StatusCode: 404 } => new Response<T>
            {
                Title = ResponseTitle.NotFound,
                ValidationErrors = GetProblemDetails(apiException.Result),
                Success = false
            },
            { StatusCode: >= 200 and <= 299 } => new Response<T>
            {
                Title = "Operation Reported Success",
                Success = true
            },

            _ => new Response<T> { Title = "Something went wrong, please try again.", Success = false }
        };
    }

    private static string? GetProblemDetails(ProblemDetails? problemDetails)
    {
        return problemDetails!.Detail;
    }
}