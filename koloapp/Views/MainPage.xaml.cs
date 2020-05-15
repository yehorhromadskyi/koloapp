using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace koloapp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<ScanPage, string>(this, "Scanned", (obj, url) =>
            {
                CurrentPage = Children[0];
            });
        }
    }
}