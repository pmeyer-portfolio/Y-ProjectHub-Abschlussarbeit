namespace ProjectHub.Blazor.Tests
{
    using FluentAssertions;
    using NSubstitute;
    using ProjectHub.Blazor.Constants;
    using ProjectHub.Blazor.Initializer;
    using ProjectHub.Blazor.Models;
    using ProjectHub.Blazor.Services.Base;
    using ProjectHub.Blazor.Services.Contracts;

    [TestFixture]
    public class DropDownDataGridInitializerTests
    {
        [SetUp]
        public void SetUp()
        {
            this.tribeService = Substitute.For<ITribeService>();
            this.programmingLanguageService = Substitute.For<IProgrammingLanguageService>();
            this.initializer = new DropDownDataGridInitializer(this.tribeService, this.programmingLanguageService)
            {
                TribeService = this.tribeService,
                ProgrammingLanguageService = this.programmingLanguageService
            };
        }

        private ITribeService tribeService = null!;
        private IProgrammingLanguageService programmingLanguageService = null!;
        private DropDownDataGridInitializer initializer = null!;

        [Test]
        public async Task InitializeProgrammingLanguages_WithFailureResponse_ReturnsEmptyList()
        {
            // Arrange
            Response<IList<ProgrammingLanguageDto>> response = new() { Success = false, Data = null };
            this.programmingLanguageService.GetAll().Returns(Task.FromResult(response));

            // Act
            IList<ProgrammingLanguageDto> result = await this.initializer.InitializeProgrammingLanguages();

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public async Task InitializeProgrammingLanguages_WithSuccessResponse_ReturnsListOfLanguages()
        {
            // Arrange
            List<ProgrammingLanguageDto> languages = new()
            {
                new() { Id = 1, Name = "C#" }
            };
            Response<IList<ProgrammingLanguageDto>> response = new() { Success = true, Data = languages };
            this.programmingLanguageService.GetAll().Returns(Task.FromResult(response));

            // Act
            IList<ProgrammingLanguageDto> result = await this.initializer.InitializeProgrammingLanguages();

            // Assert
            result.Should().HaveCount(2);
            result[0].Name.Should().Be(PlaceHolder.NotSpecified);
            result[1].Name.Should().Be("C#");
        }

        [Test]
        public async Task InitializeTribes_WithFailureResponse_ReturnsEmptyList()
        {
            // Arrange
            Response<IList<TribeDto>> response = new() { Success = false, Data = null };
            this.tribeService.GetAll().Returns(Task.FromResult(response));

            // Act
            IList<TribeDto> result = await this.initializer.InitializeTribes();

            // Assert
            result.Should().BeEmpty();
        }

        [Test]
        public async Task InitializeTribes_WithSuccessResponse_ReturnsListOfTribes()
        {
            // Arrange
            List<TribeDto> tribes = new List<TribeDto>
            {
                new() { Id = 1, Name = "Tribe1" }
            };
            Response<IList<TribeDto>> response = new() { Success = true, Data = tribes };
            this.tribeService.GetAll().Returns(Task.FromResult(response));

            // Act
            IList<TribeDto> result = await this.initializer.InitializeTribes();

            // Assert
            result.Should().HaveCount(2);
            result[0].Name.Should().Be(PlaceHolder.NotAssigned);
            result[1].Name.Should().Be("Tribe1");
        }
    }
}