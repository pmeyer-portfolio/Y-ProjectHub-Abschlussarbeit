namespace ProjectHub.Tests.Mappers.User;

using FluentAssertions;
using ProjectHub.Abstractions.DTOs.User;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Mappers.User;

[TestFixture]
public class UserMapperTests
{
    [SetUp]
    public void Setup()
    {
        this.userMapper = new UserMapper();
    }

    private UserMapper userMapper = null!;

    [Test]
    public void Map_ShouldMapAllPropertiesCorrectly()
    {
        // Arrange
        UserCreateDto userCreateDto = new()
        {
            Email = "test@example.com",
            FirstName = "John",
            LastName = "Doe"
        };

        // Act
        User result = this.userMapper.Map(userCreateDto);

        // Assert
        result.Email.Should().Be(userCreateDto.Email);
        result.FirstName.Should().Be(userCreateDto.FirstName);
        result.LastName.Should().Be(userCreateDto.LastName);
    }
}