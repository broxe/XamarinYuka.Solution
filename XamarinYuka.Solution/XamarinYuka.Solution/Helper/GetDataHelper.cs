using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinYuka.Solution.Models;
using XamarinYuka.Solution.Constants;

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
    }
}
