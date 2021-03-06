using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinYuka.Solution.Models;
using XamarinYuka.Solution.ViewModel;
using XamarinYuka.Solution.Wrapper;

namespace XamarinYuka.Solution.Views
{
    public partial class ProductAddView : ContentPage
    {
        private ProductAddViewModel ProductAddViewModelItems { get; set; }
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


        public ProductAddView()
        {
            InitializeComponent();
            ProductAddViewModelItems = new ProductAddViewModel();
            BindingContext = ProductAddViewModelItems;
        }

        async void ButtonClicked_PhotoRepertoire(System.Object sender, System.EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();

                PhotoProduit.Source = ImageSource.FromStream(() => stream);
            }
        }

        async void ButtonClicked_PhotoCamera(System.Object sender, System.EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync();

            if (result != null)
            {
                var stream = await result.OpenReadAsync();

                PhotoProduit.Source = ImageSource.FromStream(() => stream);
            }
        }

        private void ButtonClicked_Valider(object sender, EventArgs e)
        {
            ProductModel productAdded = ProductAddViewModelItems.ProductModelItems;
        }
    }
}