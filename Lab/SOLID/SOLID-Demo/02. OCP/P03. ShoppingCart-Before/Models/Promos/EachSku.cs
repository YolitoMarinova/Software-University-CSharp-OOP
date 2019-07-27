using P03._ShoppingCart.Models;
using P03._ShoppingCart_Before.Contracts;

namespace P03._ShoppingCart_Before.Models.Promos
{
    public class EachSku : ISku
    {
        public bool IsMattch(string type)
        {
            if (type.StartsWith("EACH"))
            {
                return true;
            }

            return false;
        }

        public decimal CalculatePrice(OrderItem item)
        {
            return item.Quantity * 5m;
        }
    }
}
