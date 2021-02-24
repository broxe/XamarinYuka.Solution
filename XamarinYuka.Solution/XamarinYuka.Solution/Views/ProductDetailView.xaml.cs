using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinYuka.Solution.Helper;
using XamarinYuka.Solution.Models;

namespace XamarinYuka.Solution.Views
{
    public partial class ProductDetailView : ContentPage
    {
        public ProductDetailView(string productCode)
        {
            InitializeComponent();
            InitializeViewByCodeProduct(productCode);
        }

        private async void InitializeViewByCodeProduct(string productCode)
        {
            GetDataHelper helper = new GetDataHelper();
            ProductModel product = await helper.GetProductInfoByCodeAsync(productCode);

            MyProductName.Text = product.ProductName;
            MyProductScore.Text = product.ProductScore.ToString();
            MyProductImage.Source = new UriImageSource() { Uri = new Uri(product.ProductImage) };
            MyProductProteines.Text = product.ProductProteine.ToString()+"g";
            MyProductFibres.Text = product.ProductFibre.ToString()+"g";
            MyProductSucre.Text = product.ProductSucre.ToString()+"g";
            MyProductGraisses.Text = product.ProductGraisses.ToString()+"g";
            MyProductSel.Text = product.ProductSel.ToString()+"g";
            MyProductCalories.Text = product.ProductCalories+"kcal";

        }
    }
}