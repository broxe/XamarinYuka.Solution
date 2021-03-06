using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinYuka.Solution.Models
{
    public class ProductEntityModel
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductScore { get; set; }
        public string ProductState { get; set; }
        public string ProductImage { get; set; }
        public string ProductChamp1 { get; set; }
        public string ProductChamp2 { get; set; }
        public string ProductChamp3 { get; set; }
        public string ProductChamp4 { get; set; }
        public string ProductChamp5 { get; set; }
        public string ProductChamp6 { get; set; }
    }
}
