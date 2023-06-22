using LegUp.Models;
using LegUp.Services;
using LegUp.StaticClasses;
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
	public partial class SeekHelp : ContentPage
	{
		private ServiceAPI _service = new ServiceAPI();
		public SeekHelp()
		{
			InitializeComponent();
			SetSelects();
		}

        private async void seekHelpBtn_Clicked(object sender, EventArgs e)
		{
            ProductModel product = new ProductModel
			{
				Detail = txtDetail.Text,
				Name = txtTitle.Text,
				HelpTypeId = (typeSelect.SelectedItem as PickerDto).Id,
				UniversityId = (universitySelect.SelectedItem as PickerDto).Id,
                OwnerId = UserConfig.Id,
				Price = Convert.ToInt32(txtPrice.Text),
				Status = 1
			};

            var json = JsonConvert.SerializeObject(product);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            int result = _service.PostAPI(stringContent, "Helping/CreateProduct");
			if (result == 1) {
				await DisplayAlert("İhtiyacınız Listelendi", "İhtiyacınız Başarıyla Kaydedildi.", "OK");
			}
			else
			{
                await DisplayAlert("Bir hatayla karşılaşıldı", "Lütfen tekrar deneyin.", "OK");
            }
		}

		private void SetSelects()
		{
			typeSelect.ItemsSource = JsonConvert.DeserializeObject<List<PickerDto>>(_service.GetAPI("Helping/GetTypes").Result);
			universitySelect.ItemsSource = JsonConvert.DeserializeObject<List<PickerDto>>(_service.GetAPI("Helping/GetUniversities").Result);
		}
	}
}