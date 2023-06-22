using LegUp.Models;
using LegUp.Models.DTO;
using LegUp.Services;
using LegUp.StaticClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LegUp.ViewModels
{
    public class ChatPageViewModel : INotifyPropertyChanged
    {
        private ServiceAPI _service = new ServiceAPI();
        public ObservableCollection<MessageDTO> Messages { get; set; } = new ObservableCollection<MessageDTO>();
        public string TextToSend { get; set; }
        public ICommand OnSendCommand { get; set; }

        public ChatPageViewModel()
        {
            Messages = GetMessages().Result;

            OnSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(TextToSend))
                {
                    Messages.Add(new MessageDTO() { Message = TextToSend, IsLeft = false });
                    SendMessage(TextToSend);
                    TextToSend = string.Empty;
                }

            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async Task<ObservableCollection<MessageDTO>> GetMessages()
        {
            return JsonConvert.DeserializeObject<ObservableCollection<MessageDTO>>(await _service.GetAPI($"Chat/GetMessages?chatId={UserConfig.SelectedChat}&userId={UserConfig.Id}"));
        }
        private void SendMessage(string message)
        {
            MessageModel msg = new MessageModel
            {
                ChatId = UserConfig.SelectedChat,
                Message = message,
                SenderId = UserConfig.Id
            };

            var json = JsonConvert.SerializeObject(msg);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            int result = _service.PostAPI(stringContent, "Chat/SendMessage");
        }
    }
}
