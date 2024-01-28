using ProjectMobilne.ViewModels;

namespace ProjectMobilne.Views;

public partial class ChatView : ContentPage
{
	public ChatView(NewChatViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		
	}

    
}