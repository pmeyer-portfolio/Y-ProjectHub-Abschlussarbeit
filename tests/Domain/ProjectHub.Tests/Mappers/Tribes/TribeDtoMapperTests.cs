#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace ProjectHub.Tests.Mappers.Tribes;

using FluentAssertions;
using ProjectHub.Abstractions.DTOs.Tribe;
using ProjectHub.Data.Abstractions.Entities;
using ProjectHub.Mappers.Tribes;

[TestFixture]
public class TribeDtoMapperTests
{
    [SetUp]
    public void Setup()
    {
        this.mapper = new TribeDtoMapper();

        this.tribe = new Tribe
        {
            Id = 1,
            Name = "Tribe My"
        };
    }

    private TribeDtoMapper mapper;
    private Tribe tribe;

    [Test]
    public void Map_ShouldReturnEmptyListOfDtosWhenGetsEmptyListOfTribes()
    {
        //Arrange
        IList<Tribe> tribes = new List<Tribe>();

        //Act
        IList<TribeDto> results = this.mapper.Map(tribes);

        //Assert
        results.Should().BeEmpty();
        results.Count.Should().Be(0);
    }

    [Test]
    public void Map_ShouldReturnListOfViewTribeDtosWithEquivalentValues()
    {
        //Arrange
        IList<Tribe> tribes = new List<Tribe>
        {
            this.tribe,
        };

        //Act
        IList<TribeDto> result = this.mapper.Map(tribes);

        //Assert
        result.Should().NotBeEmpty();
        result.Should().HaveCount(1);
        result.First().Id.Should().Be(this.tribe.Id);
        result.First().Name.Should().Be(this.tribe.Name);
    }

    [Test]
    public void Map_ShouldReturnViewTribeDtoWithEquivalentValues()
    {
        //Act
        TribeDto result = this.mapper.Map(this.tribe);

        //Assert
        result.Should().BeEquivalentTo(this.tribe);
        result.Id.Should().Be(this.tribe.Id);
        result.Name.Should().Be(this.tribe.Name);
    }
}