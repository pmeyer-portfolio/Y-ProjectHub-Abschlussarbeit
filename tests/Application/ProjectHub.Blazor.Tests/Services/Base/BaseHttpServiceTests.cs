namespace ProjectHub.Blazor.Tests.Services.Base;

using FluentAssertions;
using NSubstitute;
using ProjectHub.Blazor.Constants;
using ProjectHub.Blazor.Models;
using ProjectHub.Blazor.Services.Base;

public class BaseHttpServiceTests
{
    private BaseHttpService baseHttpService = null!;
    private IProjectHubApiClient projectHubApiClient = null!;

    [SetUp]
    public void SetUp()
    {
        this.projectHubApiClient = Substitute.For<IProjectHubApiClient>();
        this.baseHttpService = new BaseHttpService(this.projectHubApiClient);
    }

    [TestCase(400, ResponseTitle.BadRequest)]
    [TestCase(403, ResponseTitle.ValidationError)]
    [TestCase(404, ResponseTitle.NotFound)]
    public void GetApiExceptionResponse_WithClientErrorStatusCode_ReturnsErrorResponse(int statusCode,
        string expectedTitle)
    {
        // Arrange
        ProblemDetails problemDetails = new() { Detail = "Error Detail" };
        ApiException<ProblemDetails> apiException = new(
            "Error message",
            statusCode,
            "Error details",
            new Dictionary<string,
                IEnumerable<string>>(),
            problemDetails,
            new Exception());

        // Act
        Response<string> response = this.baseHttpService.GetApiExceptionResponse<string>(apiException);

        // Assert
        response.Title.Should().Be(expectedTitle);
        response.ValidationErrors.Should().Be("Error Detail");
        response.Success.Should().BeFalse();
    }

    [Test]
    public void GetApiExceptionResponse_WithSuccessStatusCode_ReturnsSuccessResponse()
    {
        // Arrange
        ApiException<ProblemDetails> apiException = new(
            "Success Message",
            200,
            "Success Details",
            new Dictionary<string,
                IEnumerable<string>>(),
            new ProblemDetails(),
            new Exception());

        // Act
        Response<string> response = this.baseHttpService.GetApiExceptionResponse<string>(apiException);

        // Assert
        response.Title.Should().Be("Operation Reported Success");
        response.Success.Should().BeTrue();
    }

    [Test]
    public void GetApiExceptionResponse_WithUnhandledStatusCode_ReturnsGenericErrorResponse()
    {
        // Arrange
        ApiException<ProblemDetails> apiException = new(
            "Internal Server Error Message",
            500,
            "Internal Server Error Details",
            new Dictionary<string,
                IEnumerable<string>>(),
            new ProblemDetails(),
            new Exception());

        // Act
        Response<string> response = this.baseHttpService.GetApiExceptionResponse<string>(apiException);

        // Assert
        response.Title.Should().Be("Something went wrong, please try again.");
        response.Success.Should().BeFalse();
    }
}