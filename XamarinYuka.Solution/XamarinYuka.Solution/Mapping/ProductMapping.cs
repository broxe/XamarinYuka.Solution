using System;
using System.Collections.Generic;
using System.Text;
using XamarinYuka.Solution.Models;

namespace XamarinYuka.Solution.Mapping
{
    public class ProductMapping
    {

        public static List<ProductModel> MappingProductEntityModelToProductModel(List<ProductEntityModel> productEntityList)
        {
            List<ProductModel> productModelList = new List<ProductModel>();

            foreach(var item in productEntityList)
            {
                ProductModel productModel = new ProductModel();
                productModel.ProductName = item.ProductName;
                productModel.ProductCode = item.ProductCode;
                productModel.ProductImage = item.ProductImage;
                productModel.ProductScore = item.ProductScore;
                productModel.ProductState = item.ProductState;
                productModel.ProductChamp1 = item.ProductChamp1;
                productModel.ProductChamp2 = item.ProductChamp2;
                productModel.ProductChamp3 = item.ProductChamp3;
                productModel.ProductChamp4 = item.ProductChamp4;
                productModel.ProductChamp5 = item.ProductChamp5;
                productModel.ProductChamp6 = item.ProductChamp6;
                productModelList.Add(productModel);
            }

            return productModelList;
        }

        public static List<ProductEntityModel> MappingProductModelToProductEntityModel(List<ProductModel> productModels)
        {
            List<ProductEntityModel> productEntityModels = new List<ProductEntityModel>();

            foreach (var item in productModels)
            {
                ProductEntityModel productEntityModel = new ProductEntityModel();
                productEntityModel.ProductName = item.ProductName;
                productEntityModel.ProductCode = item.ProductCode;
                productEntityModel.ProductImage = item.ProductImage;
                productEntityModel.ProductScore = item.ProductScore;
                productEntityModel.ProductState = item.ProductState;
                productEntityModel.ProductChamp1 = item.ProductChamp1;
                productEntityModel.ProductChamp2 = item.ProductChamp2;
                productEntityModel.ProductChamp3 = item.ProductChamp3;
                productEntityModel.ProductChamp4 = item.ProductChamp4;
                productEntityModel.ProductChamp5 = item.ProductChamp5;
                productEntityModel.ProductChamp6 = item.ProductChamp6;
                productEntityModels.Add(productEntityModel);
            }

            return productEntityModels;
        }

    }
}
