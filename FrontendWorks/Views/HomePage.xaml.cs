using FrontendWorks.ViewModel;
using FrontendWorks.Models;

namespace FrontendWorks.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel viewModel)
	{
        BindingContext = viewModel;
        InitializeComponent();
		
		if(App.UserInfo == null)
		{
            Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
	}
}