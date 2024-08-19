using BusyIndicatorSample.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BusyIndicatorSample.Views
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