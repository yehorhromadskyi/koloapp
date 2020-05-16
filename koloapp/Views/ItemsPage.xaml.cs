using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using koloapp.Models;
using koloapp.Views;
using koloapp.ViewModels;

namespace koloapp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        readonly ProductsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ProductsViewModel();

            MessagingCenter.Subscribe<ScanPage, Product>(this, "Scanned", async (obj, product) =>
            {
                await OpenHistoryAsync(product);
            });
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var product = (Product)layout.BindingContext;
            await OpenHistoryAsync(product);
        }

        Task OpenHistoryAsync(Product product)
        {
            return Application.Current.MainPage.Navigation.PushAsync(new ProductHistoryPage(product));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Products.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}