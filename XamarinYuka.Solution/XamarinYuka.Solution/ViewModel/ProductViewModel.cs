using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinYuka.Solution.Models;
using XamarinYuka.Solution.Wrapper;

namespace XamarinYuka.Solution.ViewModel
{
    public class ProductViewModel
    {
        public ObservableCollection<ProductModel> ListProduct { get; set; }
        static ProductLocalDatabase database;

        public static ProductLocalDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ProductLocalDatabase();
                }
                return database;
            }
        }

        public ProductViewModel()
        {
            ListProduct = new ObservableCollection<ProductModel>();
            /*ListProduct.Add(new ProductModel { ProductCode = "6221031497919", ProductName = "BIO Spaghetti", ProductScore = "10", ProductImage = "https://www.smartfooding.com/fr/14492-large_default/spaghetti-ble-et-quinoa-ail-persil-bio-500-gr.jpg", ProductState = "Bon"});
            ListProduct.Add(new ProductModel { ProductCode = "3660942051767", ProductName = "BIO Spaghetti", ProductScore = "10", ProductImage = "https://www.smartfooding.com/fr/14492-large_default/spaghetti-ble-et-quinoa-ail-persil-bio-500-gr.jpg", ProductState = "Bon" });
            */
            GetAllProductLocalBase();
        }

        private async void GetAllProductLocalBase()
        {
            ListProduct = new ObservableCollection<ProductModel>(await Database.GetItemsAsync());
        }

    }
}
