using LegUp.Models;
using LegUp.Models.DTO;
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
    public partial class SeekList : ContentPage
    {
        private ServiceAPI _service = new ServiceAPI();
        public SeekList()
        {
            InitializeComponent();
            seekList.ItemsSource = GetMessages().Result;
        }

        private async Task<List<ProductDTO>> GetMessages()
        {
            return JsonConvert.DeserializeObject<List<ProductDTO>>(await _service.GetAPI($"Helping/GetAllProducts?userId={UserConfig.Id}"));
        }
        private async void helpBtn_Clicked(object sender, EventArgs e)
        {
            var test = ((Button)sender).BindingContext;
            int productId = Convert.ToInt32(((Button)sender).BindingContext);
            ChatModel chat = new ChatModel
            {
                ApplierId = UserConfig.Id,
                ProductId= productId,
                Status = 1
            };
            var json = JsonConvert.SerializeObject(chat);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            int result = _service.PostAPI(stringContent, "Chat/StartChat");
            UserConfig.SelectedChat = result;
            await Navigation.PushModalAsync(new MessagePage());
        }
    }
}