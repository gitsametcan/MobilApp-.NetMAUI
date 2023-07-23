using FrontendWorks.ViewModel;
using FrontendWorks.Views;

namespace FrontendWorks;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		this.BindingContext = new AppShellViewModel();
		Routing.RegisterRoute(nameof(HomePage),typeof(HomePage));
	}
}
