
using ProjectMobilne.Models;
using ProjectMobilne.ViewModels;
using System.Collections.ObjectModel;

namespace ProjectMobilne.Views;

public partial class NewChatView : ContentPage
{
    
	public NewChatView(NewChatViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        viewModel.GetAssistantProfiles();
    }

    
}