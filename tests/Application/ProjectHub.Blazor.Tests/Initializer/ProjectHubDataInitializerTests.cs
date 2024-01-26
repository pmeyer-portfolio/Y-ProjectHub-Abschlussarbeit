namespace ProjectHub.Blazor.Tests.Initializer
{
    using FluentAssertions;
    using NSubstitute;
    using ProjectHub.Blazor.Constants;
    using ProjectHub.Blazor.Initializer;
    using ProjectHub.Blazor.Models;
    using ProjectHub.Blazor.Models.ProgrammingLanguage;
    using ProjectHub.Blazor.Models.Tribe;
    using ProjectHub.Blazor.Services.ProgrammingLanguage;
    using ProjectHub.Blazor.Services.Tribe;

    [TestFixture]
    public class ProjectHubDataInitializerTests
    {
        [SetUp]
        public void SetUp()
        {
            this.tribeService = Substitute.For<ITribeService>();
            this.programmingLanguageService = Substitute.For<IProgrammingLanguageService>();
            this.initializer = new ProjectHubDataInitializer(this.tribeService, this.programmingLanguageService)
            {
                TribeService = this.tribeService,
                ProgrammingLanguageService = this.programmingLanguageService
            };
        }

        private ITribeService tribeService = null!;
        private IProgrammingLanguageService programmingLanguageService = null!;
        private ProjectHubDataInitializer initializer = null!;

        [Test]
        public async Task InitializeProgrammingLanguages_WithFailureResponse_ReturnsEmptyList()
        {
            // Arrange
            Response<IList<ProgrammingLanguageViewModel>> response = new() { Success = false, Data = null };
            this.programmingLanguageService.GetAll().Returns(Task.FromResult(response));

            // Act
            IList<ProgrammingLanguageViewModel> result = await this.initializer.InitializeProgrammingLanguages();

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public async Task InitializeProgrammingLanguages_WithSuccessResponse_ReturnsListOfLanguages()
        {
            // Arrange
            List<ProgrammingLanguageViewModel> languages = new()
            {
                new() { Id = 1, Name = "C#" }
            };
            Response<IList<ProgrammingLanguageViewModel>> response = new() { Success = true, Data = languages };
            this.programmingLanguageService.GetAll().Returns(Task.FromResult(response));

            // Act
            IList<ProgrammingLanguageViewModel> result = await this.initializer.InitializeProgrammingLanguages();

            // Assert
            result.Should().HaveCount(2);
            result[0].Name.Should().Be(PlaceHolder.NotSpecified);
            result[1].Name.Should().Be("C#");
        }

        [Test]
        public async Task InitializeTribes_WithFailureResponse_ReturnsEmptyList()
        {
            // Arrange
            Response<IList<TribeViewModel>> response = new() { Success = false, Data = null };
            this.tribeService.GetAll().Returns(Task.FromResult(response));

            // Act
            IList<TribeViewModel> result = await this.initializer.InitializeTribes();

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public async Task InitializeTribes_WithSuccessResponse_ReturnsListOfTribes()
        {
            // Arrange
            List<TribeViewModel> tribes = new()
            {
                new() { Id = 1, Name = "Tribe1" }
            };
            Response<IList<TribeViewModel>> response = new() { Success = true, Data = tribes };
            this.tribeService.GetAll().Returns(Task.FromResult(response));

            // Act
            IList<TribeViewModel> result = await this.initializer.InitializeTribes();

            // Assert
            result.Should().HaveCount(2);
            result[0].Name.Should().Be(PlaceHolder.NotAssigned);
            result[1].Name.Should().Be("Tribe1");
        }
    }
}