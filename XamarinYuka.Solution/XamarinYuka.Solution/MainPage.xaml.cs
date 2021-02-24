using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinYuka.Solution.Helper;
using XamarinYuka.Solution.Models;
using XamarinYuka.Solution.ViewModel;
using XamarinYuka.Solution.Views;
using ZXing.Net.Mobile.Forms;

namespace XamarinYuka.Solution
{
    public partial class MainPage : ContentPage
    {
        private ZXingScannerPage _scanPage;
        private GetDataHelper _dataHelper;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ProductViewModel();
            _dataHelper = new GetDataHelper();
        }

        //
        //  Ouverture fenetre de detail
        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var productDetail = e.Item as ProductModel;
            await Navigation.PushModalAsync(new ProductDetailView(productDetail.ProductCode));
        }

        //
        //  Scanner un produit
        private async void ToolbarItemClicked_ScannerCode(object sender, EventArgs e)
        {
            _scanPage = new ZXingScannerPage();
            _scanPage.OnScanResult += (result) =>
            {
                _scanPage.IsScanning = false;

                // Do something with result
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                    bool productExist = await _dataHelper.IsProductExist(result.Text);
                    if(productExist)
                    {
                        await Navigation.PushModalAsync(new ProductDetailView(result.Text));
                    }
                    else
                    {
                        bool answer = await DisplayAlert("Produit non reconnu","Voulez vous ajouter ce produit à notre base ?", "Oui","Non");
                        if (answer)
                        {
                            await Navigation.PushModalAsync(new ProductAddView());
                        }
                    }
                });
            };

            await Navigation.PushModalAsync(_scanPage);
        }

        //  Pour avoir plus d'information
        private async void ToolbarItemClicked_Information(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new InformationView());
        }

        //  Ajouter un nouveau produit
        private async void ToolbarItemClicked_Ajouter(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProductAddView());
        }
    }
}
