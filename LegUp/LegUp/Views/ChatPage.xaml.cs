using LegUp.Models.DTO;
using LegUp.Services;
using LegUp.StaticClasses;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegUp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        public readonly ServiceAPI _service = new ServiceAPI();
        public ChatPage()
        {
            InitializeComponent();
            chatList.ItemsSource = GetChats().Result;
        }

        private async Task<List<ChatDTO>> GetChats()
        {
            return JsonConvert.DeserializeObject<List<ChatDTO>>(await _service.GetAPI($"Chat/GetChats?userId={UserConfig.Id}"));
        }

        private void CollectionViewListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedContact = e.CurrentSelection.FirstOrDefault() as ChatDTO;
            UserConfig.SelectedChat = selectedContact.Id;
            Navigation.PushModalAsync(new MessagePage());
        }
        
    }
}