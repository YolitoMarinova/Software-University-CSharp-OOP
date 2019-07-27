using P03._ShoppingCart.Models;
using P03._ShoppingCart_Before.Contracts;

namespace P03._ShoppingCart_Before.Models.Promos
{
    public class SpecialSku : ISku
    {
        public bool IsMattch(string type)
        {
            if (type.StartsWith("SPECIAL"))
            {
                return true;
            }

            return false;
        }

        public decimal CalculatePrice(OrderItem item)
        {
           decimal total = item.Quantity * .4m;
            int setsOfThree = item.Quantity / 3;
            total -= setsOfThree * .2m;

            return total;
        }
    }
}
