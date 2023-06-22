using LegUp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace LegUp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}