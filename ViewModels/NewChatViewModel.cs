using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectMobilne.Models;
using ProjectMobilne.Services;
using ProjectMobilne.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace ProjectMobilne.ViewModels
{
    public partial class NewChatViewModel : ObservableObject 
    {
        private readonly IProfileService _profileService;
        private readonly IApiService _apiService;
        public ObservableCollection<AssistantProfile> AssistantProfiles { get; set; } = new();
        public NewChatViewModel(IProfileService profileService, IApiService apiService)
        {
            _profileService = profileService;
            _apiService = apiService;   
        }

        [ObservableProperty]
        private AssistantProfile _selectedProfile;

        [ObservableProperty]
        private string _request;

        [ObservableProperty]
        private ChatResponseModel _chatResponse;

        [ObservableProperty]
        private string _responseText;

        [ObservableProperty]
        private string _instruction;

        [ObservableProperty]
        private bool _isResponseVisible = false;


        [RelayCommand]
        public async Task<string> SelectProfile()
        {

            Instruction = SelectedProfile.Instruction;
            //Instruction = SelectedProfile?.Instruction;
            //System.Diagnostics.Debug.WriteLine($"System Message: {Instruction}");
            await Shell.Current.GoToAsync("//Chat");
            return Instruction;

        }

        [RelayCommand]
        private async Task ProceedRequest()
        {
            MauiProgram.CurrentGptModelEmbedding = "gpt-3.5-turbo";
            MauiProgram.CurrentGptModel = "text-embedding-ada-002";
            try
            {
                IsResponseVisible = true;
                ResponseText = "";
                Console.WriteLine("request je: " + Request);
                
                //Instruction = SelectedProfile.Instruction;
                System.Diagnostics.Debug.WriteLine($"System Message: {Instruction}");

                var apiResponse = await _apiService.AskChat(Request, Instruction);

                var words = apiResponse.Content.Split(' ');
                foreach (var word in words)
                {
                    ResponseText += word + " ";

                    await Task.Delay(100);
                }
                ChatResponse = apiResponse;
                
            }
            catch (Exception ex)
            {

                await Shell.Current.DisplayAlert("Greška", ex.Message, "OK");
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
                Instruction = SelectedProfile.Instruction;
                Console.WriteLine("request je: " + Request);
                var apiResponse = await _apiService.AskChat(Request, Instruction);

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

        [RelayCommand]
        public async Task GetAssistantProfiles()
        {
           AssistantProfiles.Clear();

            try
            {
                var profile = await _profileService.GetAssistantProfiles();
                foreach (var assistantProfile in profile)
                {
                    AssistantProfiles.Add(assistantProfile);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Greška", ex.Message, "OK");
            }
        }
        [RelayCommand]
        private async Task GoBack()
        {
            ResponseText = "";
            Request = "";
            System.Diagnostics.Debug.WriteLine($"System Message: jel radi ovo");
            await Shell.Current.GoToAsync($"//NewChat", true);

        }


    }
}
