using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinYuka.Solution.Models;
using XamarinYuka.Solution.ViewModel;
using XamarinYuka.Solution.Views;
using ZXing.Net.Mobile.Forms;

namespace XamarinYuka.Solution
{
    public partial class MainPage : ContentPage
    {
        ZXingScannerPage scanPage;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ProductViewModel();
        }
        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var productDetail = e.Item as ProductModel;
            await Navigation.PushModalAsync(new ProductDetailView(productDetail.ProductName, productDetail.ProductScore, productDetail.ProductState, productDetail.ProductImage));
        }
        /*
        private async void BouttonScanDefault_Clicked(object sender, EventArgs e)
        {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;

                // Do something with result
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                    await DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };

            await Navigation.PushModalAsync(scanPage);
        }*/
    }
}
