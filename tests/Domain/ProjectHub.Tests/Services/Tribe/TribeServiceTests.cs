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
    private ITribeDtoMapper mapper = null!;
    private IGenericRepository<Tribe> repository = null!;
    private TribeService service = null!;

    [SetUp]
    public void SetUp()
    {
        this.repository = Substitute.For<IGenericRepository<Tribe>>();
        this.mapper = Substitute.For<ITribeDtoMapper>();
        this.service = new TribeService(this.repository, this.mapper);
    }

    private static Tribe GetTribe()
    {
        return new Tribe
        {
            Id = 1,
            Name = "Test Tribe"
        };
    }

    private static TribeDto GetTribeDto()
    {
        return new TribeDto
        {
            Id = 1,
            Name = "Test Tribe"
        };
    }

    [Test]
    public async Task GetAllTribes_ShouldReturnMappedTribesAsList()
    {
        //Arrange
        Tribe tribe = GetTribe();
        IList<Tribe> tribes = new List<Tribe>
            { tribe };

        TribeDto tribeDto = GetTribeDto();
        IList<TribeDto> tribeDtos = new List<TribeDto>
            { tribeDto };

        this.repository.GetAllAsync().Returns(tribes);
        this.mapper.Map(tribes).Returns(tribeDtos);

        //Act
        IList<TribeDto> results = await this.service.GetAllTribesAsync();

        //Assert
        results.Should().BeEquivalentTo(tribeDtos);
    }

    [Test]
    public async Task GetTribe_ShouldReturnMappedTribe()
    {
        //Arrange
        const int requestId = 1;
        Tribe tribe = GetTribe();
        TribeDto tribeDto = GetTribeDto();
        this.repository.GetByIdAsync(requestId).Returns(tribe);
        this.mapper.Map(tribe).Returns(tribeDto);

        //Act
        TribeDto result = (await this.service.GetTribeAsync(requestId))!;

        //Assert
        result.Should().Be(tribeDto);
    }
}