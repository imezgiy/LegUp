using LegUp.Models.DTO;
using LegUp.Views.ViewCells;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LegUp.Helper
{
    class ChatTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;

        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingMessageCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as MessageDTO;
            if (messageVm == null)
                return null;


            return (messageVm.IsLeft) ?  incomingDataTemplate : outgoingDataTemplate;
        }

    }
}
