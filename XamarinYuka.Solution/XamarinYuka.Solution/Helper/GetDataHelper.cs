using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinYuka.Solution.Models;
using XamarinYuka.Solution.Constants;
using System.Net;
using System.Collections.Specialized;

namespace XamarinYuka.Solution.Helper
{
    public class GetDataHelper
    {
        /// <summary>
        /// Fonction permet d'obtenir les informations d'un produit avec son code 
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public async Task<ProductModel> GetProductInfoByCodeAsync(string productCode)
        {
            ProductModel resultProduct = new ProductModel();
            var uri = new Uri(DataConstant.constUrlData + "?productFunction=get_info_product_by_id&codeId="+ productCode);
            HttpClient myClient = new HttpClient();

            var response = await myClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                resultProduct = JsonConvert.DeserializeObject<ProductModel>(content);
            }
            return resultProduct;
        }

        /// <summary>
        /// Fonction retourn true si le produit existe dans la base de données
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public async Task<bool> IsProductExist(string productCode)
        {
            bool resultExist = false;

            ProductModel resultProduct = new ProductModel();
            var uri = new Uri(DataConstant.constUrlData+ "?productFunction=get_info_product_by_id&codeId=" + productCode);
            HttpClient myClient = new HttpClient();

            var response = await myClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                resultProduct = JsonConvert.DeserializeObject<ProductModel>(content);
                if(!string.IsNullOrEmpty(resultProduct.ProductCode))
                {
                    if(resultProduct.ProductCode.Equals(productCode))
                    {
                        resultExist = true;
                    }
                }
            }

            return resultExist;
        }

        public void InsertLog(string logText)
        {
            string URL = DataConstant.constUrlLog;
            WebClient webClient = new WebClient();

            NameValueCollection formData = new NameValueCollection();
            formData["logText"] = logText;

            byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);
            string responsefromserver = Encoding.UTF8.GetString(responseBytes);
            Console.WriteLine(responsefromserver);
            webClient.Dispose();
        }

        public void InsertProduct ()
        {
            string URL = DataConstant.constUrlPostProduct;
            WebClient webClient = new WebClient();

            NameValueCollection formData = new NameValueCollection();
            formData["send"] = "testuser";
            formData["code"] = "testuser";
            formData["name"] = "mypassword";
            formData["score"] = "testuser";
            formData["state"] = "mypassword";
            formData["champ10"] = "testuser";
            formData["champ20"] = "mypassword";
            formData["champ30"] = "testuser";
            formData["champ40"] = "mypassword";
            formData["champ50"] = "testuser";
            formData["champ60"] = "mypassword";
            formData["champ11"] = "testuser";
            formData["champ21"] = "mypassword";
            formData["champ31"] = "testuser";
            formData["champ41"] = "mypassword";
            formData["champ51"] = "testuser";
            formData["champ61"] = "mypassword";

            byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);
            string responsefromserver = Encoding.UTF8.GetString(responseBytes);
            Console.WriteLine(responsefromserver);
            webClient.Dispose();
        }
    }
}
