using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using XamarinYuka.Solution.Models;

namespace XamarinYuka.Solution.ViewModel
{
    public class ProductAddViewModel : INotifyPropertyChanged
    {

        private ProductModel _productModelItems { get; set; }
        public ProductModel ProductModelItems
        {
            get
            {
                return _productModelItems;
            }
            set
            {
                _productModelItems = value;
                NotifyPropertyChanged();
            }
        }

        public ProductAddViewModel()
        {
            ProductModelItems = new ProductModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
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
