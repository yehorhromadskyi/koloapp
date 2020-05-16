using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using koloapp.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace koloapp.ViewModels
{
    public class ProductHistoryViewModel : BaseViewModel
    {
        private readonly Product _product;
        private readonly HttpClient _httpClient;

        public Command LoadHistoryCommand { get; set; }

        public ObservableCollection<Record> History { get; set; }


        public ProductHistoryViewModel(Product product)
        {
            _product = product;

            History = new ObservableCollection<Record>();

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://kolo-api.azurewebsites.net/")
            };

            Title = "History";
            LoadHistoryCommand = new Command(async () => await ExecuteLoadHistoryCommand());
        }

        async Task ExecuteLoadHistoryCommand()
        {
            IsBusy = true;

            try
            {
                History.Clear();

                var api = $"/api/Sellers/{_product.SellerId}/products/{_product.Id}/history";
                var response = await _httpClient.GetAsync(api);
                var json = await response.Content.ReadAsStringAsync();
                var records = JsonConvert.DeserializeObject<List<Record>>(json);

                foreach (var record in records)
                {
                    History.Add(record);
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
