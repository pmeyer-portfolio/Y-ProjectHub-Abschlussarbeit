namespace ProjectHub.Api.MiddleWares;

using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectHub.Abstractions.Exceptions.ValidationEx;

[ExcludeFromCodeCoverage]
public class GlobalExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception e)
    {
        ProblemDetails problemDetails = new();

        if (e is ValidationException)
        {
            problemDetails.Status = StatusCodes.Status400BadRequest;
            problemDetails.Detail = e.Message;
        }

        if (problemDetails.Status != null)
        {
            context.Response.StatusCode = (int)problemDetails.Status;
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }

        context.Response.ContentType = "application/problem+json";

        await context.Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
    }
}