using LegUp.Models;
using LegUp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegUp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterNew : ContentPage
    {
        private ServiceAPI _service = new ServiceAPI();
        public RegisterNew()
        {
            InitializeComponent();
            SetSelect();
        }

        private async void registerBtn_Clicked(object sender, EventArgs e)
        {
            if (txtEmail.Text.Split('@')[1].Contains("edu.com"))
            {
                UserModel user = new UserModel
                {
                    Department = txtDepartment.Text,
                    Email = txtEmail.Text,
                    Gender = txtGender.Items[txtGender.SelectedIndex] == "Erkek" ? 1 : 0,
                    Name = txtName.Text,
                    SurName = txtSurname.Text,
                    Password = txtPassword.Text,
                    RoleId = 1,
                    University = (universitySelect.SelectedItem as PickerDto).Title,
                    UserName = txtUsername.Text,
                    Status = 1
                };
                var json = JsonConvert.SerializeObject(user);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                int result = _service.PostAPI(stringContent, "Auth/CreateUser");

                if (result == 1)
                {
                    await DisplayAlert("Başarılı!", "Başarıyla Kayıt Oldunuz.", "Kapat");
                    await Navigation.PushModalAsync(new LoginPage());
                }
                else
                    await DisplayAlert("Başarısız!", "Bir Hatayla Karşılaşıldı", "Kapat");
            }
            else
            {
                await DisplayAlert("Başarısız!", "Sadece okul adresleri ile kayıt olabilirsiniz.", "Kapat");
            }
            
        }

        private void SetSelect()
        {
            universitySelect.ItemsSource = JsonConvert.DeserializeObject<List<PickerDto>>(_service.GetAPI("Helping/GetUniversities").Result);
        }
    }
}