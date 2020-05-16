using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using koloapp.Models;
using koloapp.Views;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace koloapp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; }
        public Command LoadProductsCommand { get; set; }

        private readonly HttpClient _httpClient;

        public ItemsViewModel()
        {
            Title = "Products";
            Products = new ObservableCollection<Product>();
            LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://kolo-api.azurewebsites.net/")
            };
        }

        async Task ExecuteLoadProductsCommand()
        {
            IsBusy = true;

            try
            {
                Products.Clear();

                var response = await _httpClient.GetAsync("/api/Products");
                var json = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(json);

                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}