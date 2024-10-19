using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;


namespace Q3
{
    public enum CommodityCategory
    {
        Furniture,
        Grocery,
        Service
    }
    public class Commodity
    {
        public CommodityCategory Category ;

        public string CommodityName;
        public int CommodityQuantity;
        public double CommodityPrice;

        public Commodity(CommodityCategory category, string commodityName,int commodityQuantity, double commodityPrice)
        {
            Category = category;
            CommodityName = commodityName;
            CommodityQuantity = commodityQuantity;
            CommodityPrice = commodityPrice;
            
            
        }
    }
    public class PrepareBill
    {
        private readonly IDictionary<CommodityCategory, double> _taxRates;
        public PrepareBill()
        {
            _taxRates = new Dictionary<CommodityCategory, double>();
        }
        public void SetTaxRates(CommodityCategory category, double taxRate)
        {
            _taxRates[category] = taxRate;
        }
       
        public double CalculateBillAmount(IList<Commodity> items)
        {
            double billAmount = 0;
            
           
                foreach (var item in items)
                {
                    double taxRate = _taxRates.ContainsKey(item.Category) ? _taxRates[item.Category] : 0;
                    double itemtotal = item.CommodityQuantity * item.CommodityPrice;
                    double itemTax = itemtotal * ( taxRate / 100);
                    billAmount += itemtotal +itemTax;
                }
                
            
            return billAmount;
        }
    }
        public class Program
        {
            static void Main(string[] args)
            {
                var commodities = new List<Commodity>()
                {
                    new Commodity(CommodityCategory.Furniture, "Bed", 2, 50000),
                    new Commodity(CommodityCategory.Grocery, "Flour", 5, 80),
                    new Commodity(CommodityCategory.Service, "Insurance", 8, 8500)
                };
            var prepareBill = new PrepareBill();
            prepareBill.SetTaxRates(CommodityCategory.Furniture, 18);
            prepareBill.SetTaxRates(CommodityCategory.Grocery, 5);
            prepareBill.SetTaxRates(CommodityCategory.Service, 12);

            var billAmount = prepareBill.CalculateBillAmount(commodities);
            Console.WriteLine($"{billAmount}");
            }
        }
    
}
