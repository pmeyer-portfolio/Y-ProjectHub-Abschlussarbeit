namespace ProjectHub.Blazor.Tests.Services.Project
{
    using FluentAssertions;
    using ProjectHub.Blazor.Models.ProgrammingLanguage;
    using ProjectHub.Blazor.Models.Project;
    using ProjectHub.Blazor.Models.Tribe;
    using ProjectHub.Blazor.Services.Project;

    [TestFixture]
    public class ProjectFilterServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            this.projectFilterService = new ProjectFilterService();
            this.projectFilterModel = new ProjectFilterModel();
            this.projectViewModels = new List<ProjectViewModel>();
        }

        private ProjectFilterService projectFilterService = null!;
        private ProjectFilterModel projectFilterModel = null!;
        private List<ProjectViewModel> projectViewModels = null!;

        [TestCase("TribeA", "TribeA", true)]
        [TestCase("TribeA", "TribeB", false)]
        public void MatchesTribeName_ShouldMatchCorrectly(string projectTribeName, string filterTribeName,
            bool expected)
        {
            bool result = ProjectFilterService.MatchesTribeName(projectTribeName, filterTribeName);
            result.Should().Be(expected);
        }

        [TestCase("New", "New", true)]
        [TestCase("Old", "New", false)]
        public void MatchesStatus_ShouldMatchCorrectly(string projectStatus, string filterStatus, bool expected)
        {
            bool result = ProjectFilterService.MatchesStatus(projectStatus, filterStatus);
            result.Should().Be(expected);
        }

        [TestCase("2021-06-15", "2021-06-15", true)]
        [TestCase("2021-06-15", "2021-06-14", false)]
        [TestCase("2021-06-15", null, true)]
        public void MatchesDateTime_WithSpecificDateTime_ShouldMatchCorrectly(DateTime createdAt,
            DateTime? specificDateTime, bool expected)
        {
            this.projectFilterModel.SpecificDateTime = specificDateTime;
            bool result = ProjectFilterService.MatchesDateTime(createdAt, this.projectFilterModel);
            result.Should().Be(expected);
        }

        [TestCase("2021-06-15", "2021-06-01", "2021-06-30", true)]
        [TestCase("2021-06-15", null, "2021-06-30", true)]
        [TestCase("2021-06-15", "2021-06-01", null, true)]
        [TestCase("2021-06-15", "2021-06-16", "2021-06-30", false)]
        [TestCase("2021-06-15", "2021-05-01", "2021-06-14", false)]
        public void MatchesDateTime_WithRange_ShouldMatchCorrectly(DateTime createdAt, DateTime? fromDateTime,
            DateTime? toDateTime, bool expected)
        {
            this.projectFilterModel.FromDateTime = fromDateTime;
            this.projectFilterModel.ToDateTime = toDateTime;
            bool result = ProjectFilterService.MatchesDateTime(createdAt, this.projectFilterModel);
            result.Should().Be(expected);
        }

        private static TribeViewModel CreateTribeViewModel(int id, string name)
        {
            return new TribeViewModel
            {
                Id = id,
                Name = name
            };
        }

        private static ProgrammingLanguageViewModel CreateProgrammingLanguageViewModel(int id, string name)
        {
            return new ProgrammingLanguageViewModel
            {
                Id = id,
                Name = name
            };
        }

        [Test]
        [TestCase(2, "Java")]
        public void Filter_WithAllConditionsMatching_ShouldReturnFilteredProjects(int tribeId, string tribeName)
        {
            this.projectViewModels.Add(new ProjectViewModel
            {
                TribeViewModel = CreateTribeViewModel(1, "Tribe My"),
                Status = "Active",
                ProgrammingLanguageViewModels = new List<ProgrammingLanguageViewModel>
                    { CreateProgrammingLanguageViewModel(1, "C#") },
                CreatedAt = new DateTime(2021, 6, 15)
            });
            this.projectViewModels.Add(new ProjectViewModel
            {
                TribeViewModel = CreateTribeViewModel(2, "Tribe Delta"),
                Status = "Inactive",
                ProgrammingLanguageViewModels = new List<ProgrammingLanguageViewModel>
                    { CreateProgrammingLanguageViewModel(2, "Java") },
                CreatedAt = new DateTime(2021, 7, 15)
            });

            this.projectFilterModel.TribeName = "Tribe My";
            this.projectFilterModel.Status = "Active";
            this.projectFilterModel.ProgrammingLanguage = "C#";
            this.projectFilterModel.SpecificDateTime = new DateTime(2021, 6, 15);

            IList<ProjectViewModel> result =
                this.projectFilterService.Filter(this.projectFilterModel, this.projectViewModels);

            result.Should().HaveCount(1);
            result.First().TribeViewModel.Name.Should().Be("Tribe My");
            result.First().Status.Should().Be("Active");
            result.First().ProgrammingLanguageViewModels.Should().ContainSingle(pl => pl.Name == "C#");
            result.First().CreatedAt.Should().Be(new DateTime(2021, 6, 15));
        }


        [Test]
        public void Filter_WithNoConditionsMatching_ShouldReturnEmptyList()
        {
            this.projectViewModels.Add(new ProjectViewModel
            {
                TribeViewModel = CreateTribeViewModel(1,"TribeA"),
                Status = "Active",
                ProgrammingLanguageViewModels = new List<ProgrammingLanguageViewModel>
                    { CreateProgrammingLanguageViewModel(1, "C#") },
                CreatedAt = new DateTime(2021, 6, 15)
            });

            this.projectFilterModel.TribeName = "TribeB";
            this.projectFilterModel.Status = "Inactive";
            this.projectFilterModel.ProgrammingLanguage = "Java";
            this.projectFilterModel.SpecificDateTime = new DateTime(2021, 6, 16);

            IList<ProjectViewModel> result =
                this.projectFilterService.Filter(this.projectFilterModel, this.projectViewModels);
            result.Should().BeEmpty();
        }

        [Test]
        public void MatchesProgrammingLanguage_WithContainedLanguage_ShouldReturnTrue()
        {
            List<string> programmingLanguages = new List<string> { "C#", "Java" };
            bool result = ProjectFilterService.MatchesProgrammingLanguage(programmingLanguages, "Java");
            result.Should().BeTrue();
        }

        [Test]
        public void MatchesProgrammingLanguage_WithNonContainedLanguage_ShouldReturnFalse()
        {
            List<string> programmingLanguages = new List<string> { "C#", "Java" };
            bool result = ProjectFilterService.MatchesProgrammingLanguage(programmingLanguages, "Python");
            result.Should().BeFalse();
        }

        [Test]
        public void MatchesProgrammingLanguage_WithNullFilter_ShouldReturnTrue()
        {
            List<string> programmingLanguages = new List<string> { "C#", "Java" };
            bool result = ProjectFilterService.MatchesProgrammingLanguage(programmingLanguages, null);
            result.Should().BeTrue();
        }
    }
}