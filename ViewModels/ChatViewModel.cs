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
            MauiProgram.CurrentGptModelEmbedding = "gpt-3.5-turbo";
            MauiProgram.CurrentGptModel = "text-embedding-ada-002";
            try
            {
                ResponseText = "";
                Console.WriteLine("request je: " + Request);
                var apiResponse = await _apiService.AskChat(Request);
               
                var words = apiResponse.Content.Split(' ');
                foreach (var word in words)
                {
                    ResponseText += word + " ";

                    await Task.Delay(100);
                }
                ChatResponse = apiResponse;
            }
            catch (Exception)
            {

                await Application.Current.MainPage.DisplayAlert("Error", "Problem with retrieving response from chat.", "OK");
            }
           
        }
        [RelayCommand]
        private async Task ProceedRequestImage()
        {
            MauiProgram.CurrentGptModelEmbedding = "dall-e-2";
            MauiProgram.CurrentGptModel = "dall-e-2";
            try
            {
                ResponseText = "";
                Console.WriteLine("request je: " + Request);
                var apiResponse = await _apiService.AskChat(Request);

                //var words = apiResponse.Content.Split(' ');
                //foreach (var word in words)
                //{
                //    ResponseText += word + " ";

                //    await Task.Delay(100);
                //}
                ChatResponse = apiResponse;
            }
            catch (Exception)
            {

                await Application.Current.MainPage.DisplayAlert("Error", "Problem with retrieving response from chat.", "OK");
            }

        }
    }
}
