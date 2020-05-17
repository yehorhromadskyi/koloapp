using System;
using koloapp.Models;
using koloapp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace koloapp.Views
{
    public partial class ProductPage : ContentPage
    {
        private readonly ProductViewModel viewModel;

        public ProductPage(Product product)
        {
            InitializeComponent();

            BindingContext = viewModel = new ProductViewModel(product);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Seller is null)
                viewModel.IsBusy = true;
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            if ((sender as StackLayout)?.BindingContext is Document document)
            {
                await Launcher.OpenAsync($"https://kolo-api.azurewebsites.net/api/Documents/{document.Id}");
            }

            if ((sender as ImageButton)?.BindingContext is Document document1)
            {
                await Launcher.OpenAsync($"https://kolo-api.azurewebsites.net/api/Documents/{document1.Id}");
            }
        }
    }
}
