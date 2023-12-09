using FrontendWorks.Models;
using FrontendWorks.Service;
using FrontendWorks.UserControl;
using FrontendWorks.Views;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendWorks.ViewModel
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _password;

        private readonly ILoginRepo _loginRep;

        public LoginPageViewModel(ILoginRepo loginServices)
        {
            _loginRep = loginServices;
        }


        #region Commands
        [ICommand]
        public async void Login()
        {
            if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password))
            {
                //UserInfo userInfo = await _loginRep.Authenticate(UserName, Password);

                
                
                var response = await _loginRep.Authenticate(new LoginRequest
                {
                    userName = UserName,
                    password = Password
                });

                if (response != null)
                {
                    UserInfo userInfo = response.user;

                    if (Preferences.ContainsKey(nameof(App.UserInfo)))
                    {
                        Preferences.Remove(nameof(App.UserInfo));
                    }

                    await SecureStorage.SetAsync(nameof(App.Token), response.token);

                    string userDetails = JsonConvert.SerializeObject(userInfo);
                    Preferences.Set(nameof(App.UserInfo), userDetails);
                    App.UserInfo = userInfo;        

                    AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                }
                else
                {
                    await AppShell.Current.DisplayAlert("Invalid", "Username or Password", "OK");
                }
                
            }
        }
        #endregion
    }
}
