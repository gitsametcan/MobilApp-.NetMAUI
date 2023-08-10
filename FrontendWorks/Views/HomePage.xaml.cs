using FrontendWorks.ViewModel;

namespace FrontendWorks.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel viewModel)
	{
		InitializeComponent();
		if(App.UserInfo == null)
		{
            Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
	}
}