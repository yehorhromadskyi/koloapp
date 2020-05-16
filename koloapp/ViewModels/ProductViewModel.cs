using System;
using System.Diagnostics;
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

        public Command LoadDataCommand { get; set; }

        public Seller Seller { get; set; }
        public Product Product { get; set; }

        public ProductViewModel(Product product)
        {
            Product = product;
            OnPropertyChanged(nameof(Product));

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
                var api = $"/api/Sellers/{Product.SellerId}";
                var response = await _httpClient.GetAsync(api);
                var json = await response.Content.ReadAsStringAsync();
                var seller = JsonConvert.DeserializeObject<Seller>(json);

                Seller = seller;
                OnPropertyChanged(nameof(Seller));
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
