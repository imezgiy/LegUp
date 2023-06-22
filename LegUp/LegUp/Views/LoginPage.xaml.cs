using LegUp.Models;
using LegUp.Services;
using LegUp.StaticClasses;
using LegUp.ViewModels;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegUp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public readonly ServiceAPI _service = new ServiceAPI();
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        public async void btnLogin_Clicked(object sender, EventArgs e)
        {
            UserModel x = JsonConvert.DeserializeObject<UserModel>(await _service.GetAPI($"Auth/LoginCheck?UserName={txtUserName.Text}&Password={txtPassword.Text}"));
            if (x != null)
            {
                UserConfig.SetConfig(x);
                
                await Navigation.PushModalAsync(new StudentPage());
            }
            else
            {
                await DisplayAlert("Üzgünüz :(", "Böyle bir kullanıcı bulunamadı.", "Kapat");
            }
        }

        private async void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterNew());
        }
    }
}