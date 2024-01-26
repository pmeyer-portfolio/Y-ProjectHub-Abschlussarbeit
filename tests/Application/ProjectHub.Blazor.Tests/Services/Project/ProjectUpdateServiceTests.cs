namespace ProjectHub.Blazor.Tests.Services.Project
{
    using FluentAssertions;
    using NSubstitute;
    using ProjectHub.Blazor.Constants;
    using ProjectHub.Blazor.Interfaces;
    using ProjectHub.Blazor.Models;
    using ProjectHub.Blazor.Models.Project;
    using ProjectHub.Blazor.Services.Base;
    using ProjectHub.Blazor.Services.Project;
    using ProjectHub.Blazor.Services.Project.Interfaces;
    using Radzen;

    [TestFixture]
    public class ProjectUpdateServiceTests
    {
        [SetUp]
        public void SetUp()
        {
            this.projectService = Substitute.For<IProjectService>();
            this.notificationServiceWrapper = Substitute.For<INotificationServiceWrapper>();
            this.projectUpdateService = new ProjectUpdateService(this.projectService, this.notificationServiceWrapper);
        }

        private IProjectService projectService = null!;
        private INotificationServiceWrapper notificationServiceWrapper = null!;
        private ProjectUpdateService projectUpdateService = null!;

        [Test]
        public void Notify_ShouldNotUpdateDetachedObservers()
        {
            IObserver? observerOne = Substitute.For<IObserver>();
            this.projectUpdateService.Attach(observerOne);

            this.projectUpdateService.Detach(observerOne);
            this.projectUpdateService.NotifyUpdate();

            observerOne.DidNotReceive().Update();
        }

        [Test]
        public void Notify_ShouldUpdateAllObservers()
        {
            IObserver? observerOne = Substitute.For<IObserver>();
            this.projectUpdateService.Attach(observerOne);

            this.projectUpdateService.NotifyUpdate();

            observerOne.Received(1).Update();
        }

        [Test]
        public async Task UpdateProject_WhenNoUpdates_ResponseSuccessShouldBeFalse()
        {
            ProjectUpdateModel updateModel = new() { projectHaveUpdates = false };

            Response<ProjectUpdateDto> result = await this.projectUpdateService.UpdateProject(updateModel);

            this.notificationServiceWrapper.Received(1)
                .Notify(Arg.Is<NotificationMessage>(m => m.Severity == NotificationSeverity.Error
                                                         && m.Summary == NotificationSummary.UpdateIncomplete &&
                                                         m.Detail == NotificationDetails.UpdateIncomplete));
            result.Success.Should().BeFalse();
            await this.projectService.DidNotReceiveWithAnyArgs().Update(updateModel);
        }

        [Test]
        public async Task UpdateProject_WhenUpdateFails_ShouldResponseSuccessShouldBeFalse()
        {
            const string apiErrorMessage = "Api nicht erreichbar.";
            ProjectUpdateModel updateModel = new() { projectHaveUpdates = true };
            this.projectService.Update(updateModel).Returns(new Response<ProjectUpdateDto> 
                { Success = false, DetailMessage = apiErrorMessage});

            Response<ProjectUpdateDto> result = await this.projectUpdateService.UpdateProject(updateModel);

            result.Success.Should().BeFalse();
            this.notificationServiceWrapper.Received()
                .Notify(Arg.Is<NotificationMessage>(m => m.Severity == NotificationSeverity.Error
                && m.Summary == NotificationSummary.UpdateIncomplete &&
                m.Detail == apiErrorMessage));
        }

        [Test]
        public async Task UpdateProject_WhenUpdateSucceeds_ResponseSuccessShouldBeTrue()
        {
            ProjectUpdateModel updateModel = new() { projectHaveUpdates = true };
            this.projectService.Update(updateModel).Returns(new Response<ProjectUpdateDto> { Success = true });

            Response<ProjectUpdateDto> result = await this.projectUpdateService.UpdateProject(updateModel);

            result.Success.Should().BeTrue();
        }
    }
}