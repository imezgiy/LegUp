using LegUp.StaticClasses;
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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            SetUserInfos();
        }

        private void SetUserInfos()
        {
            txtFullname.Text = $"{UserConfig.Name} {UserConfig.Surname}";
            txtEmail.Text = $"{UserConfig.Email}";
            txtUniversity.Text = $"{UserConfig.University}";
            txtDepartment.Text = $"{UserConfig.Department}";
            txtGender.Text = $"{UserConfig.Gender}";
            txtScore.Text = $"{UserConfig.HelpScore}";
        }


        private async void mySeek_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MySeeksPage());
        }
    }
}