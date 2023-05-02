using Azure;
using Azure.AI.OpenAI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Runtime.CompilerServices;
using Windows.Media.Protection.PlayReady;

namespace MauiAppSample.ViewModels
{
    public partial class MainPageViewModel : ObservableValidator
    {

        [ObservableProperty]
        private string _inputText;

        [ObservableProperty]
        private string _replyText = "ReplyMessage";

        private OpenAIClient _openAIClient;

        public MainPageViewModel()
        {
            _openAIClient = new OpenAIClient(
                new Uri("EndPoint"),
                new AzureKeyCredential("Key"));
        }

        [RelayCommand]
        private async Task SendMessage()
        {
            if (string.IsNullOrWhiteSpace(InputText))
            {
                return;
            }

            ValidateAllProperties();

            // ChatGPTに送信する
            try
            {
                ReplyText = await GetReplyAsync(InputText);
            }
            catch (Exception ex)
            {
                ReplyText = "Error";
            }
        }

        /// <summary>
        /// メッセージを送信します
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        private async Task<string> GetReplyAsync(string prompt)
        {
            var response = await _openAIClient.GetChatCompletionsAsync(
                "Model",
                new ChatCompletionsOptions()
                {
                    Messages =
                    {
                    new ChatMessage(ChatRole.System, @""),
                    new ChatMessage(ChatRole.User, prompt)
                    },
                    // 温度パラメータ
                    Temperature = (float)0.7,
                    // 最大トークン数パラメータ
                    MaxTokens = 5000,
                    // 上位Pパラメータ
                    NucleusSamplingFactor = (float)0.95,
                    FrequencyPenalty = 0,
                    PresencePenalty = 0,
                });

            var res = response.Value;

            return res.Choices[0].Message.Content;

        }

    }
}
