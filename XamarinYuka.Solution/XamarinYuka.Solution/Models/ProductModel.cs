using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinYuka.Solution.Models
{
    public class ProductModel
    {
        public string ProductName { get; set; }
        public int ProductScore { get; set; }
        public string ProductState { get; set; }
        public string ProductImage { get; set; }
        public ProductNutritionModel ProductNutrition { get; set; }
    }
}
