using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMobilne.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        //private readonly IUserRepository _userRepository;
        private readonly FirebaseAuthClient _firebaseAuthClient;

        public LoginViewModel(/*IUserRepository userRepository,*/ FirebaseAuthClient firebaseAuthClient)
        {
            //_userRepository = userRepository;
            _firebaseAuthClient = firebaseAuthClient;
            //Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        [RelayCommand]
        private async Task Login()
        {
            
            try
            {
                await _firebaseAuthClient.SignInWithEmailAndPasswordAsync(Email, Password);
                await Application.Current.MainPage.DisplayAlert("Successfuly", "You have signed in.", "OK");
                Email = string.Empty;
                Password = string.Empty;
                await Shell.Current.GoToAsync("//MainPage");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to sign in, try again later.", "OK");
            }
        }
    }
}
