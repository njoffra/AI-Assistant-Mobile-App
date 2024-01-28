using ProjectMobilne.ViewModels;

namespace ProjectMobilne.Views;

public partial class ImageView : ContentPage
{
	public ImageView(NewChatViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}