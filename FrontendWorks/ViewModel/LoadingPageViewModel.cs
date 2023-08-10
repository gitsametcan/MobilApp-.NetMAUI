using FrontendWorks.Models;
using FrontendWorks.UserControl;
using FrontendWorks.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendWorks.ViewModel
{
    public class LoadingPageViewModel
    {
        public LoadingPageViewModel() 
        {
            CheckUserLoginDetails();

        }

        private async void CheckUserLoginDetails()
        {
            string userDetailsStr = Preferences.Get(nameof(App.UserInfo),"");

            if (string.IsNullOrEmpty(userDetailsStr))
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                var tokenDetails = await SecureStorage.GetAsync(nameof(App.Token));

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(tokenDetails) as JwtSecurityToken;

                if(jsonToken.ValidTo < DateTime.Now)
                {
                    await Shell.Current.DisplayAlert("User session expired", "Login again", "OK");
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                }
                else
                {
                    var userDetails = JsonConvert.DeserializeObject<UserInfo>(userDetailsStr);
                    App.UserInfo = userDetails;
                    AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                }

            }
        }
    }
}
