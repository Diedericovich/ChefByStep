using ChefByStep.Xamarin.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ChefByStep.Xamarin.Views
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