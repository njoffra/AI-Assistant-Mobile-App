using ProjectMobilne.ViewModels;

namespace ProjectMobilne.Views;

public partial class RegisterView : ContentPage
{
	public RegisterView(RegisterViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}