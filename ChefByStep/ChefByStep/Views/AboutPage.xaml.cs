using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChefByStep.Views
{
    using Syncfusion.XForms.Buttons;

    public partial class AboutPage : ContentPage
    {

        private SfSegmentedControl segmentedControl;
        public AboutPage()
        {
            InitializeComponent();
            segmentedControl = new SfSegmentedControl();
            this.Content = segmentedControl;
        }
    }
}