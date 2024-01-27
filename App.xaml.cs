namespace ProjectMobilne;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
    protected override async void OnStart()
    {
		await Shell.Current.GoToAsync("//NewChat");
        base.OnStart();
    }
}
