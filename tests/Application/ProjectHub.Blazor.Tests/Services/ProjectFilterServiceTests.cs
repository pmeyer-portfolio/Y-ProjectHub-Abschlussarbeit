namespace ProjectHub.Blazor.Tests.Services
{
    using FluentAssertions;
    using ProjectHub.Blazor.Models;
    using ProjectHub.Blazor.Services;

    [TestFixture]
    public class ProjectFilterServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            this.service = new ProjectFilterService();
            this.filterModel = new ProjectFilterModel();
            this.projects = new List<ProjectViewModel>();
        }

        private ProjectFilterService service = null!;
        private ProjectFilterModel filterModel = null!;
        private List<ProjectViewModel> projects = null!;

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
            this.filterModel.SpecificDateTime = specificDateTime;
            bool result = ProjectFilterService.MatchesDateTime(createdAt, this.filterModel);
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
            this.filterModel.FromDateTime = fromDateTime;
            this.filterModel.ToDateTime = toDateTime;
            bool result = ProjectFilterService.MatchesDateTime(createdAt, this.filterModel);
            result.Should().Be(expected);
        }

        [Test]
        public void Filter_WithAllConditionsMatching_ShouldReturnFilteredProjects()
        {
            this.projects.Add(new ProjectViewModel
            {
                TribeName = "TribeA", Status = "Active", ProgrammingLanguages = new List<string> { "C#" },
                CreatedAt = new DateTime(2021, 6, 15)
            });
            this.projects.Add(new ProjectViewModel
            {
                TribeName = "TribeB", Status = "Inactive", ProgrammingLanguages = new List<string> { "Java" },
                CreatedAt = new DateTime(2021, 7, 15)
            });

            this.filterModel.TribeName = "TribeA";
            this.filterModel.Status = "Active";
            this.filterModel.ProgrammingLanguage = "C#";
            this.filterModel.SpecificDateTime = new DateTime(2021, 6, 15);

            IList<ProjectViewModel> result = this.service.Filter(this.filterModel, this.projects);
            result.Should().HaveCount(1);
            result.First().TribeName.Should().Be("TribeA");
            result.First().Status.Should().Be("Active");
            result.First().ProgrammingLanguages.Should().Contain("C#");
            result.First().CreatedAt.Should().Be(new DateTime(2021, 6, 15));
        }

        [Test]
        public void Filter_WithNoConditionsMatching_ShouldReturnEmptyList()
        {
            this.projects.Add(new ProjectViewModel
            {
                TribeName = "TribeA", Status = "Active", ProgrammingLanguages = new List<string> { "C#" },
                CreatedAt = new DateTime(2021, 6, 15)
            });

            this.filterModel.TribeName = "TribeB";
            this.filterModel.Status = "Inactive";
            this.filterModel.ProgrammingLanguage = "Java";
            this.filterModel.SpecificDateTime = new DateTime(2021, 6, 16);

            IList<ProjectViewModel> result = this.service.Filter(this.filterModel, this.projects);
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