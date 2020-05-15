using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        void scanView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Scanned result", "The barcode's text is " + result.Text + ". The barcode's format is " + result.BarcodeFormat, "OK");
            });
        }
    }
}
