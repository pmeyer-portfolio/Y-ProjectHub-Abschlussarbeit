namespace ProjectHub.Blazor.Tests.Services;

using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services;
using ProjectHub.Blazor.Services.Base;

[TestFixture]
public class ProgrammingLanguageServiceTests
{
    [SetUp]
    public void SetUp()
    {
        this._apiClient = Substitute.For<IProjectHubApiClient>();
        this._sut = new ProgrammingLanguageService(this._apiClient);
    }

    private ProgrammingLanguageService _sut;
    private IProjectHubApiClient _apiClient;

    [Test]
    public async Task GetAll_WhenApiExceptionOccurs_ReturnsErrorResponse()
    {
        // Arrange
        ApiException<ProblemDetails> apiException = new(
            "Error message",
            500,
            "Error details",
            new Dictionary<string,
                IEnumerable<string>>(),
            new ProblemDetails(),
            new Exception());
        this._apiClient.ApiProgrammingLanguagesGetAsync().Throws(apiException);

        // Act
        Response<IList<ProgrammingLanguageDto>> result = await this._sut.GetAll();

        // Assert
        result.Should().NotBeNull();
        result.Success.Should().BeFalse();
        result.Data.Should().BeNull();
    }

    [Test]
    public async Task GetAll_WhenCalled_ReturnsSuccessWithData()
    {
        // Arrange
        List<ProgrammingLanguageDto> programmingLanguages = new List<ProgrammingLanguageDto>
        {
            new() { Name = "C#" },
            new() { Name = "Java" }
        };

        this._apiClient.ApiProgrammingLanguagesGetAsync().Returns(programmingLanguages);

        // Act
        Response<IList<ProgrammingLanguageDto>> result = await this._sut.GetAll();

        // Assert
        result.Should().NotBeNull();
        result.Success.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(programmingLanguages);
    }
}