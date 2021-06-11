using ChefByStep.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ChefByStep.Views
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