using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinYuka.Solution.Views
{
    public partial class ProductDetailView : ContentPage
    {
        public ProductDetailView(string productName, int productScore, string productState, string productImage)
        {
            InitializeComponent();

            MyProductName.Text = productName;
            MyProductScore.Text = productState;
            MyProductImage.Source = new UriImageSource() { Uri = new Uri(productImage) };
            MyProductProteines.Text = "12g";
            MyProductFibres.Text = "3.5g";
            MyProductSucre.Text = "3.2g";
            MyProductGraisses.Text = "0.3g";
            MyProductSel.Text = "0g";
            MyProductCalories.Text = "350";
        }

    }
}