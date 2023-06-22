using LegUp.Models.DTO;
using LegUp.Services;
using LegUp.StaticClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LegUp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MySeeksPage : ContentPage
	{
		private ServiceAPI _service = new ServiceAPI();
		public MySeeksPage ()
		{
			InitializeComponent ();
            seekList.ItemsSource = GetMessages().Result; 

        }

        private async Task<List<ProductDTO>> GetMessages()
        {
            return JsonConvert.DeserializeObject<List<ProductDTO>>(await _service.GetAPI($"Helping/GetProductsByOwner?userId={UserConfig.Id}"));
        }

        private void helpBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}