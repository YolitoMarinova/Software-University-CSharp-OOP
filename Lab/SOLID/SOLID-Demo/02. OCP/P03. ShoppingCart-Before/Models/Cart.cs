namespace P03._ShoppingCart.Models
{
    using P03._ShoppingCart_Before.Models;
    using System.Collections.Generic;

    public class Cart
    {
        private readonly List<OrderItem> items;
        private PricingCalculator pricingCalculator;

        public Cart()
        {
            this.items = new List<OrderItem>();
        }

        public IEnumerable<OrderItem> Items
        {
            get { return new List<OrderItem>(this.items); }
        }

        public string CustmerEmail { get; set; }

        public void Add(OrderItem orderItem)
        {
            this.items.Add(orderItem);
        }

        public decimal TotalAmount()
        {
            decimal total = 0m;

            foreach (var item in this.items)
            {
                total = this.pricingCalculator.TotalPrice(item);
            }

            return total; 
        }
    }
}
