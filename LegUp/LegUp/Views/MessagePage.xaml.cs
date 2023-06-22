using LegUp.Services;
using LegUp.StaticClasses;
using LegUp.ViewModels;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegUp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePage : ContentPage
    {
        private ServiceAPI _service = new ServiceAPI();
        public MessagePage()
        {
            InitializeComponent();
            this.BindingContext = new ChatPageViewModel();
            CheckPermission();
        }

        private void CheckPermission()
        {
            int ownerId = JsonConvert.DeserializeObject<int>(_service.GetAPI($"Chat/GetChatOwner?chatId={UserConfig.SelectedChat}").Result);
            if(ownerId != UserConfig.Id)
            {
                dealBtn.IsVisible = false;
            }
        }

        private async void dealBtn_Clicked(object sender, System.EventArgs e)
        {
            int result = JsonConvert.DeserializeObject<int>(_service.GetAPI($"Chat/Deal?chatId={UserConfig.SelectedChat}").Result);
            if(result == 1)
            {
                await DisplayAlert("Başarılı", "Anlaşmaya vardınız!", "Teşekkürler");
                await Navigation.PushModalAsync(new ChatPage());
            }
        }
    }
}