using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using koloapp.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace koloapp.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;
        private Product _product;

        public Command LoadDataCommand { get; set; }

        public Seller Seller { get; set; }
        public Product Product { get; set; }

        public ObservableCollection<Seller> Locals { get; set; }

        public ProductViewModel(Product product)
        {
            _product = product;
            Locals = new ObservableCollection<Seller>();
            LoadDataCommand = new Command(async () => await ExecuteLoadDataCommand());

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://kolo-api.azurewebsites.net/")
            };
        }

        private async Task ExecuteLoadDataCommand()
        {
            IsBusy = true;

            try
            {
                Locals.Clear();

                var apiSeller = $"/api/Sellers/{_product.SellerId}";
                var responseSeller = await _httpClient.GetAsync(apiSeller);
                var jsonSeller = await responseSeller.Content.ReadAsStringAsync();
                var seller = JsonConvert.DeserializeObject<Seller>(jsonSeller);

                Seller = seller;
                OnPropertyChanged(nameof(Seller));

                var apiProducts = $"/api/Sellers/{_product.SellerId}/Products";
                var responseProducts = await _httpClient.GetAsync(apiProducts);
                var jsonProducts = await responseProducts.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(jsonProducts);

                Product = products.FirstOrDefault(p => p.Id == _product.Id);
                OnPropertyChanged(nameof(Product));

                var apiSellers = $"/api/Sellers";
                var responseSellers = await _httpClient.GetAsync(apiSellers);
                var jsonSellers = await responseSellers.Content.ReadAsStringAsync();
                var sellers = JsonConvert.DeserializeObject<List<Seller>>(jsonSellers);
                foreach (var localSeller in sellers)
                {
                    Locals.Add(localSeller);
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
