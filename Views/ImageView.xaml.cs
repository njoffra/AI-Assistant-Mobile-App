using ProjectMobilne.ViewModels;

namespace ProjectMobilne.Views;

public partial class ImageView : ContentPage
{
	public ImageView(ChatViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}