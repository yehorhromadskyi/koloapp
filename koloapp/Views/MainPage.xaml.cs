using System;
using System.ComponentModel;
using koloapp.Models;
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

            MessagingCenter.Subscribe<ScanPage, Product>(this, "Scanned", (obj, _) =>
            {
                CurrentPage = Children[0];
            });
        }
    }
}