using ChatGptNet.Models.Common;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectMobilne.Models;
using ProjectMobilne.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMobilne.ViewModels
{
    public partial class ChatViewModel : ObservableObject
    {
        private readonly IApiService _apiService;
        public ChatViewModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        [ObservableProperty]
        private string _request;

        [ObservableProperty]
        private ChatResponseModel _chatResponse;

        [ObservableProperty]
        private string _responseText;

        [RelayCommand]
        private async Task ProceedRequest()
        {
            try
            {
                ResponseText = "";
                Console.WriteLine("request je: " + Request);
                var apiResponse = await _apiService.AskChat(Request);
                var words = apiResponse.Content.Split(' ');
                foreach (var word in words)
                {
                    ResponseText += word + " ";

                    // Adjust the delay based on your preference
                    await Task.Delay(100);
                }
                ChatResponse = apiResponse;
            }
            catch (Exception)
            {

                await Application.Current.MainPage.DisplayAlert("Error", "Problem with retrieving response from chat.", "OK");
            }
           
        }
    }
}
