using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectMobilne.Models;
using ProjectMobilne.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace ProjectMobilne.ViewModels
{
    public partial class NewChatViewModel :ObservableObject 
    {
        private readonly IProfileService _profileService;
        public ObservableCollection<AssistantProfile> AssistantProfiles { get; set; } = new();
        public NewChatViewModel(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [ObservableProperty]
        private AssistantProfile _selectedProfile;

        [ObservableProperty]
        private int _profileId;
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
        public async Task<int> SelectProfile(AssistantProfile profile)
        {
            
            SelectedProfile = AssistantProfiles.FirstOrDefault(profile => profile.Id == ProfileId);

            return ProfileId;

            // You can perform any additional actions here if needed.
        }

    }
}
