namespace ProjectHub.Mappers.User;

using ProjectHub.Abstractions.DTOs.User;
using ProjectHub.Abstractions.IMappers.User;
using ProjectHub.Data.Abstractions.Entities;

public class UserMapper : IUserMapper
{
    public User Map(UserCreateDto userCreateDto)
    {
        return new User
        {
            Email = userCreateDto.Email!,
            FirstName = userCreateDto.FirstName,
            LastName = userCreateDto.LastName,
        };
    }
}