namespace ProjectHub.Blazor.Tests.Services;

using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.Contracts;

public class TribeServiceTests
{
    private IProjectHubApiClient projectHubApiClient = null!;
    private ITribeService TribeService { get; set; } = null!;

    [SetUp]
    public void SetUp()
    {
        this.projectHubApiClient = Substitute.For<IProjectHubApiClient>();
        this.TribeService = new TribeService(this.projectHubApiClient);
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

        IList<TribeDto> expectedDtos = new List<TribeDto>
        {
            new() { Id = 1, Name = "Tribe Gamma" }
        };

        //Act
        Response<IList<TribeDto>> result = await this.TribeService.GetAll();

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
        Response<IList<TribeDto>> response = await this.TribeService.GetAll();

        // Assert
        response.Success.Should().BeFalse();
        response.ValidationErrors.Should().Be(exception.Result.Detail);
    }
}