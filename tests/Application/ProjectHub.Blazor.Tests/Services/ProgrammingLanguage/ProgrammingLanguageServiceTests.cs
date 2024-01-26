namespace ProjectHub.Blazor.Tests.Services.ProgrammingLanguage;

using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using ProjectHub.Blazor.Mappers.ProgrammingLanguage;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Models.ProgrammingLanguage;
using ProjectHub.Blazor.Services.Base;
using ProjectHub.Blazor.Services.ProgrammingLanguage;

[TestFixture]
public class ProgrammingLanguageServiceTests
{
    [SetUp]
    public void SetUp()
    {
        this.apiClient = Substitute.For<IProjectHubApiClient>();
        this.programmingLanguageViewModelMapper = Substitute.For<IProgrammingLanguageViewModelMapper>();
        this.programmingLanguageService =
            new ProgrammingLanguageService(this.apiClient, this.programmingLanguageViewModelMapper);
    }

    private ProgrammingLanguageService programmingLanguageService = null!;
    private IProgrammingLanguageViewModelMapper programmingLanguageViewModelMapper = null!;
    private IProjectHubApiClient apiClient = null!;

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
        this.apiClient.ApiProgrammingLanguagesGetAsync().Throws(apiException);

        // Act
        Response<IList<ProgrammingLanguageViewModel>> result = await this.programmingLanguageService.GetAll();

        // Assert
        result.Should().NotBeNull();
        result.Success.Should().BeFalse();
        result.Data.Should().BeNull();
    }

    [Test]
    public async Task GetAll_WhenCalled_ReturnsSuccessWithData()
    {
        // Arrange
        IList<ProgrammingLanguageDto> programmingLanguages = new List<ProgrammingLanguageDto>
        {
            new() { Id = 1, Name = "C#" },
            new() { Id = 2, Name = "Java" }
        };

        IList<ProgrammingLanguageViewModel> programmingLanguageViewModels = new List<ProgrammingLanguageViewModel>
        {
            new() { Id = 1, Name = "C#" },
            new() { Id = 2, Name = "Java" }
        };

        this.apiClient.ApiProgrammingLanguagesGetAsync().Returns(programmingLanguages);
        programmingLanguageViewModelMapper.Map(programmingLanguages).Returns(programmingLanguageViewModels);

        // Act
        Response<IList<ProgrammingLanguageViewModel>> result = await programmingLanguageService.GetAll();

        // Assert
        result.Should().NotBeNull();
        result.Success.Should().BeTrue();
        result.Data.Should().BeEquivalentTo(programmingLanguageViewModels);
    }
}