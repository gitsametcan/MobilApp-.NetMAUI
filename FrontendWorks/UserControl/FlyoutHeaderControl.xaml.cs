namespace FrontendWorks.UserControl;

public partial class FlyoutHeaderControl : ContentView
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();
		if(App.UserInfo != null)
		{
			lblUserName.Text = "Login User" + App.UserInfo.UserName;
			lblUserEmail.Text = "Mail" + App.UserInfo.UserName;
		}
	}
}