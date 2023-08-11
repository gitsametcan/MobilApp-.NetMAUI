using FrontendWorks.Handlers;
using FrontendWorks.Models;
using Microsoft.Maui.Platform;

namespace FrontendWorks;

public partial class App : Application
{
	public static UserInfo UserInfo;

	public static string Token;
	public App()
	{
		InitializeComponent();
		//Borderless Entry
		Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
		{
			if (view is BorderlessEntry)
			{
#if __ANDROID__
				handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
				handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
			}
		});

		MainPage = new AppShell();
	}
}
