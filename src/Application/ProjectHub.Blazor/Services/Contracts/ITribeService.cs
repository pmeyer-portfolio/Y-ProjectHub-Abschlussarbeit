namespace ProjectHub.Blazor.Services.Contracts;

using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;

public interface ITribeService
{
    Task<Response<IList<TribeDto>>> GetAll();
}