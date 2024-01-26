namespace ProjectHub.Blazor.Tests.Services.Tribe;

using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using ProjectHub.Blazor.Mappers.Tribe;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Models.Tribe;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Tribe;

public class TribeServiceTests
{
    private IProjectHubApiClient projectHubApiClient = null!;
    private ITribeService TribeService { get; set; } = null!;
    private ITribeViewModelMapper TribeViewModelMapper { get; set; } = null!;

    [SetUp]
    public void SetUp()
    {
        this.projectHubApiClient = Substitute.For<IProjectHubApiClient>();
        this.TribeViewModelMapper = Substitute.For<ITribeViewModelMapper>();
        this.TribeService = new TribeService(this.projectHubApiClient, this.TribeViewModelMapper);
    }

    [Test]
    public async Task GetAll_ShouldReturnResponseWithListOfTribeDtos_SuccessShouldBeTrue()
    {
        //Arrange
        IList<TribeDto> tribeDtos = new List<TribeDto>
        {
            new() { Id = 1, Name = "Tribe Gamma" }
        };
        this.projectHubApiClient.ApiTribesGetAsync().Returns(tribeDtos);

        IList<TribeViewModel> expectedDtos = new List<TribeViewModel>
        {
            new() { Id = 1, Name = "Tribe Gamma" }
        };

        this.TribeViewModelMapper.Map(tribeDtos).Returns(expectedDtos);

        //Act
        Response<IList<TribeViewModel>> result = await this.TribeService.GetAll();

        //Assert
        result.Data.Should().NotBeNullOrEmpty();
        result.Data!.Count.Should().Be(1);
        result.Success.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(expectedDtos);
    }

    [Test]
    public async Task GetAll_WhenApiExceptionThrown_ShouldReturnErrorResponse()
    {
        // Arrange
        ApiException<ProblemDetails> exception = new(
            "Error message",
            500,
            "Error details",
            new Dictionary<string,
                IEnumerable<string>>(),
            new ProblemDetails(),
            new Exception());

        this.projectHubApiClient.ApiTribesGetAsync().Throws(exception);

        // Act
        Response<IList<TribeViewModel>> response = await this.TribeService.GetAll();

        // Assert
        response.Success.Should().BeFalse();
        response.ValidationErrors.Should().Be(exception.Result.Detail);
    }
}