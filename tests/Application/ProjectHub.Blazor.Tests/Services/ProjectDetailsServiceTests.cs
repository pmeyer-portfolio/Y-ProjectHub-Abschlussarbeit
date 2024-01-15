namespace ProjectHub.Blazor.Tests.Services
{
    using FluentAssertions;
    using NSubstitute;
    using ProjectHub.Blazor.Models;
    using ProjectHub.Blazor.Services;
    using ProjectHub.Blazor.Services.Contracts;
    using Radzen;

    [TestFixture]
    public class ProjectDetailsServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            this.projectService = Substitute.For<IProjectService>();
            this.detailsService = new ProjectDetailsService(this.projectService, this.notificationService);
        }

        private readonly NotificationService notificationService = null!;
        private IProjectService projectService = null!;
        private ProjectDetailsService detailsService = null!;

        [Test]
        [TestCase(1)]
        public async Task LoadProjectDetails_WhenProjectDoesNotExist_ShouldReturnEmptyProjectDetails(int requestId)
        {
            this.projectService.GetById(Arg.Any<int>()).Returns(new Response<ProjectDetailsViewModel> { Data = null });

            ProjectDetailsViewModel result = await this.detailsService.LoadProjectDetails(requestId);

            result.Should().BeEquivalentTo(new ProjectDetailsViewModel());
        }

        // alle Properties?
        [Test]
        [TestCase(1)]
        public async Task LoadProjectDetails_WhenProjectExists_ShouldReturnProjectDetails(int requestId)
        {
            ProjectDetailsViewModel expectedProjectDetails = new()
            {
                Id = 1,
            };
            this.projectService.GetById(Arg.Any<int>()).Returns(new Response<ProjectDetailsViewModel>
                { Data = expectedProjectDetails });

            ProjectDetailsViewModel result = await this.detailsService.LoadProjectDetails(requestId);

            result.Should().BeEquivalentTo(expectedProjectDetails);
        }
    }
}