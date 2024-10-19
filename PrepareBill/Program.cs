using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using static PrepareBill.Commodity;

namespace PrepareBill
{
    enum CommodityCategoy
    {
        Furniture,
        Grocery,
        Service

    }
    public class Commodity
    {
        public CommodityCategory Category ; 
        public string CommodityName ; 
        public int CommodityQuantity ;
        public double CommodityPrice ; 

        public Commodity(CommodityCategory category, string commodityName, int commodityQuantity, double commodityPrice)
        {
           this.Category = category ;
            this.CommodityName = commodityName;
            this.CommodityQuantity = commodityQuantity;
            this.CommodityPrice = commodityPrice;
        }

        public class CommodityCategory
        {
        }
    }
    public class PrepareBill
    {
        private readonly IDictionary<CommodityCategory, double> _taxRates;

        public PrepareBill()
        {
            void SetTaxRates(CommodityCategory category, double taxRate)
            {

            }
        }
    }

    

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
