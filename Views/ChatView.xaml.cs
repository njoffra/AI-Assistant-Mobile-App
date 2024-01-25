using ProjectMobilne.ViewModels;

namespace ProjectMobilne.Views;

public partial class ChatView : ContentPage
{
	public ChatView(ChatViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}