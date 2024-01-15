namespace ProjectHub.Blazor.Tests.Services
{
    using FluentAssertions;
    using NSubstitute;
    using ProjectHub.Blazor.Interfaces;
    using ProjectHub.Blazor.Models;
    using ProjectHub.Blazor.Services;
    using ProjectHub.Blazor.Services.Base;
    using ProjectHub.Blazor.Services.Contracts;
    using Radzen;

    [TestFixture]
    public class ProjectUpdateServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            this.projectService = Substitute.For<IProjectService>();
            this.notificationService = Substitute.For<NotificationService>();
            this.projectUpdateService = new ProjectUpdateService(this.projectService, this.notificationService);
        }

        private IProjectService projectService = null!;
        private NotificationService notificationService = null!;
        private ProjectUpdateService projectUpdateService = null!;


        // Liste von Observern in Service public -> dann Add testen? 
        [Test]
        public void Attach_ShouldAddObserver()
        {
            IObserver? observer = Substitute.For<IObserver>();
            IList<IObserver> observers = new List<IObserver>();
            Action action = () =>  this.projectUpdateService.Attach(observer);
        }

        // Liste von Observern in Service public -> dann Add + Remove testen? 
        [Test]
        public void Detach_ShouldRemoveObserver()
        {
            IObserver? observer = Substitute.For<IObserver>();
            IList<IObserver> observers = new List<IObserver>();
            this.projectUpdateService.Attach(observer);
            this.projectUpdateService.Detach(observer);
        }

        [Test]
        public void Notify_ShouldUpdateAllObservers()
        {
            IObserver? observerOne = Substitute.For<IObserver>();
            IObserver? observerTwo = Substitute.For<IObserver>();
            this.projectUpdateService.Attach(observerOne);
            this.projectUpdateService.Attach(observerTwo);

            this.projectUpdateService.Notify();

            observerOne.Received(1).Update();
            observerTwo.Received(1).Update();
        }

        //ist das so korrekt?
        [Test]
        public async Task UpdateProjectStatus_ShouldCallUpdate_AndReturnResponse()
        {
            Response<ProjectUpdateDto> expectedResponse = new()
            {
                Success = true,
                Data = new ProjectUpdateDto()
                {
                    Id = 1,
                    Status = "New Status"
                }
            };

            this.projectService.Update(Arg.Any<ProjectUpdateModel>()).Returns(expectedResponse);

            Response<ProjectUpdateDto> response = await this.projectUpdateService.UpdateProjectStatus(1, "New Status");
            
            response.Should().BeEquivalentTo(expectedResponse);
            await this.projectService.Received(1).Update(Arg.Any<ProjectUpdateModel>());
        }
    }
}