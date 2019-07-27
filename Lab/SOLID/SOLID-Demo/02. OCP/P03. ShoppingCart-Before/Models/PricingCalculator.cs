using System.Linq;
using System.Collections.Generic;
using P03._ShoppingCart_Before.Contracts;
using P03._ShoppingCart_Before.Models.Promos;
using P03._ShoppingCart.Models;

namespace P03._ShoppingCart_Before.Models
{
    public class PricingCalculator
    {
        List<ISku> allSku = new List<ISku>()
                { new EachSku(),
                new WeightSku(),
                new SpecialSku()};

        public decimal TotalPrice(OrderItem item)
        {
            return this.allSku
                .First(x=>x.IsMattch(item.Sku))
                .CalculatePrice(item);
        }
    }
}
