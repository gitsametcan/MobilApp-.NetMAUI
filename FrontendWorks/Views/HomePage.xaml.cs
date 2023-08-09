namespace FrontendWorks.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		if(App.UserInfo == null)
		{
            Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
	}
}