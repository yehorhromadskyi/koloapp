using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using koloapp.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace koloapp.Views
{
    [DesignTimeVisible(false)]
    public partial class ScanPage : ContentPage
    {
        public ScanPage()
        {
            InitializeComponent();
        }

        async void scanView_OnScanResult(ZXing.Result result)
        {
            if (result.BarcodeFormat == ZXing.BarcodeFormat.QR_CODE && !string.IsNullOrEmpty(result.Text))
            {
                try
                {
                    var product = JsonConvert.DeserializeObject<Product>(result.Text);
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        MessagingCenter.Send(this, "Scanned", product);
                    });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    await DisplayAlert("Scanning results", "There was an error scanning the QR", "OK");
                }
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            scanView.IsAnalyzing = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            scanView.IsAnalyzing = false;
        }
    }
}
