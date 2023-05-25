using MauiAppSample.Services;
using MauiAppSample.ViewModels;
using Moq;

namespace MauiAppSampleTest
{
    public class MainPageVieModelTest
    {
        [Fact]
        public void UsingAlertServiceMoqTest()
        {
            var alertServiceMock = new Mock<IAlertService>();

            alertServiceMock.Setup(o => o.ShowAlertAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.CompletedTask);

            var viewModel = new MainPageViewModel(alertServiceMock.Object);

            // �󗓂ő��M
            viewModel.InputText = string.Empty;
            var result = viewModel.SendMessageCommand.ExecuteAsync(null);

            Assert.Equal(Task.CompletedTask, result);
        }

        [Fact]
        public void UsingAlertServiceTest()
        {
            // AlertService���g���ăe�X�g���Ă݂�
            var viewModel = new MainPageViewModel(new AlertService());

            // �󗓂ő��M
            viewModel.InputText = string.Empty;
            var result = viewModel.SendMessageCommand.ExecuteAsync(null);

            // ���s����
            Assert.Equal(Task.CompletedTask, result);
        }
    }
}