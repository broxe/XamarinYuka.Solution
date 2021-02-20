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
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}