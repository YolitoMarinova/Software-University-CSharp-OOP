using P03._ShoppingCart.Models;
using P03._ShoppingCart_Before.Contracts;

namespace P03._ShoppingCart_Before.Models.Promos
{
    public class WeightSku : ISku
    {
        public bool IsMattch(string type)
        {
            if (type.StartsWith("WEIGHT"))
            {
                return true;
            }

            return false;
        }

        public decimal CalculatePrice(OrderItem item)
        {
            return item.Quantity * 4m / 1000; ;
        }
    }
}
