using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinYuka.Solution.Views
{
    public partial class ProductAddView : ContentPage
    {
        public ProductAddView()
        {
            InitializeComponent();
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

    }
}