using ProjectMobilne.ViewModels;

namespace ProjectMobilne.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}