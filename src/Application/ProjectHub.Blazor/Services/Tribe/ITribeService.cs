namespace ProjectHub.Blazor.Services.Tribe;

using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Models.Tribe;
using ProjectHub.Blazor.Services.Base;

public interface ITribeService
{
    Task<Response<IList<TribeViewModel>>> GetAll();
}