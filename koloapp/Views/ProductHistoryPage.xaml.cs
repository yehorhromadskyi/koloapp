using System;
using System.Collections.Generic;
using System.ComponentModel;
using koloapp.Models;
using koloapp.ViewModels;
using Xamarin.Forms;

namespace koloapp.Views
{
    [DesignTimeVisible(false)]
    public partial class ProductHistoryPage : ContentPage
    {
        readonly ProductHistoryViewModel viewModel;

        public ProductHistoryPage(Product product)
        {
            InitializeComponent();

            BindingContext = viewModel = new ProductHistoryViewModel(product);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.History.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}
