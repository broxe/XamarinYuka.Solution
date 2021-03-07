using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using XamarinYuka.Solution.Models;
using XamarinYuka.Solution.Wrapper;
using XamarinYuka.Solution.Mapping;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamarinYuka.Solution.ViewModel
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        static ProductLocalDatabase database;
        private ObservableCollection<ProductModel> _listProduct { get; set; }
        public ObservableCollection<ProductModel> ListProduct 
        {
            get
            {
                return _listProduct;
            }
            set
            {
                _listProduct = value;
                NotifyPropertyChanged();
            }
        }
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
            
            Task.Run(async () => {
                ListProduct = new ObservableCollection<ProductModel>(ProductMapping.MappingProductEntityModelToProductModel(await Database.GetItemsAsync()));
            });
        }

        public async void RefreshAllProduct()
        {
            ListProduct = new ObservableCollection<ProductModel>(ProductMapping.MappingProductEntityModelToProductModel(await Database.GetItemsAsync()));
        }

        public async void DeleteProductByCode(string codePorduct)
        {
            await Database.DeleteItemByCode(codePorduct);
        }
        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
