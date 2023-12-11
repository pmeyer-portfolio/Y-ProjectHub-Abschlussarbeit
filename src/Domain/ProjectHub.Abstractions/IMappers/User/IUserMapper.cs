namespace ProjectHub.Abstractions.IMappers.User;

using ProjectHub.Abstractions.DTOs.User;
using ProjectHub.Data.Abstractions.Entities;

public interface IUserMapper
{
    User Map(UserCreateDto userCreateDto);
}