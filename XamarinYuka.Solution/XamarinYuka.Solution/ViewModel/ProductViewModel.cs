using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinYuka.Solution.Models;

namespace XamarinYuka.Solution.ViewModel
{
    public class ProductViewModel
    {
        public ObservableCollection<ProductModel> ListProduct { get; set; }

        public ProductViewModel()
        {
            ListProduct = new ObservableCollection<ProductModel>();
            ListProduct.Add(new ProductModel { ProductCode = "123", ProductName = "BIO Spaghetti", ProductScore = "10", ProductImage = "https://www.smartfooding.com/fr/14492-large_default/spaghetti-ble-et-quinoa-ail-persil-bio-500-gr.jpg", ProductState = "Bon"});
            ListProduct.Add(new ProductModel { ProductCode = "456", ProductName = "Velouté BIO", ProductScore = "10", ProductImage = "https://www.carrefour.fr/media/540x540/Photosite/PGC/EPICERIE/3560070409976_PHOTOSITE_20200204_175204_0.jpg?placeholder=1", ProductState = "Bon"});
            ListProduct.Add(new ProductModel { ProductCode = "789", ProductName = "Soupe aux 12 légumes", ProductScore = "10", ProductImage = "https://www.webecologie.com/17317-large_default/soupe-12-legumes-bio.jpg", ProductState = "Bon" });
            
        }

    }
}
