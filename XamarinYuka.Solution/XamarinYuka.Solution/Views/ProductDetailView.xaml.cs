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
using XamarinYuka.Solution.ViewModel;
using XamarinYuka.Solution.Mapping;

namespace XamarinYuka.Solution.Views
{
    public partial class ProductDetailView : ContentPage
    {
        public ProductDetailView(string productCode)
        {
            InitializeComponent();
            InitializeViewByCodeProduct(productCode);
            AddProductToLocalBase(productCode);
        }

        private async void InitializeViewByCodeProduct(string productCode)
        {
            GetDataHelper helper = new GetDataHelper();
            ProductModel product = await helper.GetProductInfoByCodeAsync(productCode);

            MyProductName.Text = product.ProductName;
            MyProductScore.Text = product.ProductScore.ToString();
            MyProductImage.Source = new UriImageSource() { Uri = new Uri(product.ProductImage) };

            string[] auxProduct = product.ProductChamp1.Split(';'); ;
            if (auxProduct.Length > 1)
            {
                MyLabelChamp1.IsEnabled = true;
                MyProductChamp1.IsEnabled = true;
                MyLabelChamp1.Text = auxProduct[0];
                MyProductChamp1.Text = auxProduct[1] + "g";
            }
            else
            {
                MyLabelChamp1.IsEnabled = false;
                MyProductChamp1.IsEnabled = false;
                MyStackChamp1.IsVisible = false;
            }

            auxProduct = product.ProductChamp2.Split(';');
            if (auxProduct.Length > 1)
            {
                MyLabelChamp2.IsEnabled = true;
                MyProductChamp2.IsEnabled = true;
                MyLabelChamp2.Text = auxProduct[0];
                MyProductChamp2.Text = auxProduct[1] + "g";
            }
            else
            {
                MyLabelChamp2.IsEnabled = false;
                MyProductChamp2.IsEnabled = false;
                MyStackChamp2.IsVisible = false;
            }

            auxProduct = product.ProductChamp3.Split(';');
            if (auxProduct.Length > 1)
            {
                MyLabelChamp3.IsEnabled = true;
                MyProductChamp3.IsEnabled = true;
                MyLabelChamp3.Text = auxProduct[0];
                MyProductChamp3.Text = auxProduct[1] + "g";
            }
            else
            {
                MyLabelChamp3.IsEnabled = false;
                MyProductChamp3.IsEnabled = false;
                MyStackChamp3.IsVisible = false;
            }

            auxProduct = product.ProductChamp4.Split(';');
            if (auxProduct.Length > 1)
            {
                MyLabelChamp4.IsEnabled = true;
                MyProductChamp4.IsEnabled = true;
                MyLabelChamp4.Text = auxProduct[0];
                MyProductChamp4.Text = auxProduct[1] + "g";
            }
            else
            {
                MyLabelChamp4.IsEnabled = false;
                MyProductChamp4.IsEnabled = false;
                MyStackChamp4.IsVisible = false;
            }

            auxProduct = product.ProductChamp5.Split(';');
            if (auxProduct.Length > 1)
            {
                MyLabelChamp5.IsEnabled = true;
                MyProductChamp5.IsEnabled = true;
                MyLabelChamp5.Text = auxProduct[0];
                MyProductChamp5.Text = auxProduct[1] + "g";
            }
            else
            {
                MyLabelChamp5.IsEnabled = false;
                MyProductChamp5.IsEnabled = false;
                MyStackChamp5.IsVisible = false;
            }

            auxProduct = product.ProductChamp6.Split(';');
            if (auxProduct.Length > 1)
            {
                MyLabelChamp6.IsEnabled = true;
                MyProductChamp6.IsEnabled = true;
                MyLabelChamp6.Text = auxProduct[0];
                MyProductChamp6.Text = auxProduct[1] + "kcal";
            }
            else
            {
                MyLabelChamp6.IsEnabled = false;
                MyProductChamp6.IsEnabled = false;
                MyStackChamp6.IsVisible = false;
            }
            
        }

        /// <summary>
        /// Ajouter produit dans base de données local
        /// </summary>
        /// <param name="productCode"></param>
        private async void AddProductToLocalBase(string productCode)
        {
            var isProductExist = await ProductViewModel.Database.GetItemAsync(productCode);
            if(!string.IsNullOrEmpty(isProductExist.ProductCode))
            {
                GetDataHelper helper = new GetDataHelper();
                ProductModel product = await helper.GetProductInfoByCodeAsync(productCode);
                List<ProductModel> listProduct = new List<ProductModel>() { product };
                await ProductViewModel.Database.SaveItemAsync(ProductMapping.MappingProductModelToProductEntityModel(listProduct).First(), false);
            }
            
        }
    }
}