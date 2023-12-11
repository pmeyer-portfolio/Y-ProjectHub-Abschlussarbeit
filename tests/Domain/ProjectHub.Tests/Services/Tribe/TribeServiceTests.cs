#pragma warning disable CS0169 // Field is never used
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ProjectHub.Tests.Services.Tribe;

using FluentAssertions;
using NSubstitute;
using ProjectHub.Abstractions.DTOs.Tribe;
using ProjectHub.Abstractions.IMappers.Tribe;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Data.Abstractions.IRepositories;
using ProjectHub.Services.Tribe;

public class TribeServiceTests
{
    private TribeDto dto;
    private ITribeDtoMapper mapper;
    private IGenericRepository<Tribe> repository;
    private TribeService service;
    private Tribe tribe;

    [SetUp]
    public void SetUp()
    {
        this.repository = Substitute.For<IGenericRepository<Tribe>>();
        this.mapper = Substitute.For<ITribeDtoMapper>();
        this.service = new TribeService(this.repository, this.mapper);

        this.tribe = new Tribe
        {
            Id = 1,
            Name = "Test Tribe"
        };

        this.dto = new TribeDto
        {
            Id = this.tribe.Id,
            Name = this.tribe.Name,
        };
    }

    [Test]
    public async Task GetAllTribes_ShouldReturnMappedTribesAsList()
    {
        //Arrange
        IList<Tribe> tribes = new List<Tribe>
            { this.tribe };

        IList<TribeDto> dtos = new List<TribeDto>
            { this.dto };

        this.repository.GetAllAsync().Returns(tribes);
        this.mapper.Map(tribes).Returns(dtos);

        //Act
        IList<TribeDto> results = await this.service.GetAllTribesAsync();

        //Assert
        results.Should().BeEquivalentTo(dtos);
    }

    [Test]
    public async Task GetTribe_ShouldReturnMappedTribe()
    {
        //Arrange
        const int requestId = 1;

        this.repository.GetByIdAsync(requestId).Returns(this.tribe);
        this.mapper.Map(this.tribe).Returns(this.dto);

        //Act
        TribeDto result = (await this.service.GetTribeAsync(requestId))!;

        //Assert
        result.Should().Be(this.dto);
    }
}