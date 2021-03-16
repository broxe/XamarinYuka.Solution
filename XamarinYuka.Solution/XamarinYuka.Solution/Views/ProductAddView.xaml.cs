using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinYuka.Solution.Constants;
using XamarinYuka.Solution.Helper;
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
            InsertProduct();
            GetDataHelper helper = new GetDataHelper();
            helper.InsertLog("Ajout nouveau produit");
            ProductModel productAdded = ProductAddViewModelItems.ProductModelItems;
        }

        /*private async void UploadImage(Stream mfile, string fileName)
        {
            int authorID = 2;
            string username = "yourusername";

            string url = DataConstant.constUrlInsertData;
            url += "?id=" + authorID + "&username=" + username; //any parameters you want to send to the php page.

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(DataConstant.constUrlData);
                MultipartFormDataContent form = new MultipartFormDataContent();

                var stream = mfile;
                StreamContent content = new StreamContent(stream);

                //get file's ext
                string fileExt = fileName.Substring(fileName.Length - 4);
                string fName = "User-Name-Here-123" + fileExt.ToLower();

                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "fileToUpload",
                    FileName = fName
                };
                form.Add(content);
                var response = await client.PostAsync(url, form);
                var result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                //debug
                var mssg = ex.Message;
                return;
            }
        }*/

        
    }
}