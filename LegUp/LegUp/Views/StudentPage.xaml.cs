using LegUp.StaticClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegUp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentPage : ContentPage
    {
        public StudentPage()
        {
            InitializeComponent();
            Test();
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
           Navigation.PushModalAsync(new StudentPage());
        }
        private async void Test()
        {
            welcomeText.Text = $"Hoşgeldin {UserConfig.Name}";
            await DisplayAlert("Giriş Başarılı", $"Hoşgeldin {UserConfig.Name}!", "Teşekkürler");
        }

        private async void profileBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProfilePage());
        }

        private async void helpBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SeekList());
        }

        private async void seekHelpBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SeekHelp());
        }

        private async void logoutBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }

        private async void chatBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ChatPage());
        }
    }
}