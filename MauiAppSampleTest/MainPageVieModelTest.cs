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

            // 空欄で送信
            viewModel.InputText = string.Empty;
            var result = viewModel.SendMessageCommand.ExecuteAsync(null);

            Assert.Equal(Task.CompletedTask, result);
        }

        [Fact]
        public void UsingAlertServiceTest()
        {
            // AlertServiceを使ってテストしてみる
            var viewModel = new MainPageViewModel(new AlertService());

            // 空欄で送信
            viewModel.InputText = string.Empty;
            var result = viewModel.SendMessageCommand.ExecuteAsync(null);

            // 失敗する
            Assert.Equal(Task.CompletedTask, result);
        }
    }
}