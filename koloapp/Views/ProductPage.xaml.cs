using System;
using koloapp.Models;
using koloapp.ViewModels;
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
    }
}
