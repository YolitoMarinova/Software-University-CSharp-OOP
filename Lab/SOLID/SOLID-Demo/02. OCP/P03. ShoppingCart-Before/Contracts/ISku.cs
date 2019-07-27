using P03._ShoppingCart;
using P03._ShoppingCart.Models;

namespace P03._ShoppingCart_Before.Contracts
{
    public interface ISku
    {
        bool IsMattch(string type);

        decimal CalculatePrice(OrderItem item);
    }
}
