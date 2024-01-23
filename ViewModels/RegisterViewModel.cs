
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using ProjectMobilne.Models;
using ProjectMobilne.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMobilne.ViewModels
{
    
    public partial class RegisterViewModel : ObservableObject
    {
        //private readonly IUserRepository _userRepository;
        private readonly FirebaseAuthClient _firebaseAuthClient;

        public RegisterViewModel(/*IUserRepository userRepository,*/ FirebaseAuthClient firebaseAuthClient)
        {
            //_userRepository = userRepository;
            _firebaseAuthClient = firebaseAuthClient;
            //Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private string _confirmPassword;

        [RelayCommand]
        private async Task Register()
        {
            if(Password != ConfirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Password and confirm password do not match", "OK");
                return;
            }
            try
            {
                await _firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(Email, Password);
                await Application.Current.MainPage.DisplayAlert("Successfuly", "You have registered your account.", "OK");
                Email = string.Empty;
                Password = string.Empty;
                ConfirmPassword = string.Empty;
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to register, try again later.", "OK");
            }
        }

        //[ObservableProperty]
        //private UserModel _user;
        //private async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        //{
        //    if (e.NetworkAccess == NetworkAccess.Internet)
        //    {
        //        await ShowToast("Ponovo is online");
           
        //    }
        //    else
        //    {
        //        await ShowToast("Nestala konekcija");
        //    }
        //}
        //private async Task ShowToast(string message)
        //{
        //    ToastDuration duration = ToastDuration.Long;
        //    double fontSize = 16;
        //    var toast = Toast.Make(message, duration, fontSize);

        //    await toast.Show(CancellationToken.None);
        //}
    }
}
