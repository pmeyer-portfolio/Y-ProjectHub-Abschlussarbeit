namespace ProjectHub.Blazor.Services.Base;

using ProjectHub.Blazor.Constants;
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
                Title = ResponseTitle.OperationSuccess,
                Success = true
            },

            _ => new Response<T> { Title = ResponseTitle.UnknownFailure, Success = false }
        };
    }

    private static string? GetProblemDetails(ProblemDetails? problemDetails)
    {
        return problemDetails!.Detail;
    }
}