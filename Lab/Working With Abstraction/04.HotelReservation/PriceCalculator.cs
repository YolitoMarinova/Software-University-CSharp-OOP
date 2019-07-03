using System;
using System.Collections.Generic;
using System.Text;

namespace _04.HotelReservation
{
    class PriceCalculator
    {
        private decimal pricePerDay;
        private int days;
        private Season season;
        private DiscountType discount;
        private decimal totalPrice;
        public PriceCalculator(decimal pricePerDay, int days, Season season, DiscountType discount)
        {
            this.pricePerDay = pricePerDay;
            this.days = days;
            this.season = season;
            this.discount = discount;
        }

        public decimal CalculatePrice()
        {
            int multiply = (int)season;
            decimal discountMultiply = (decimal)discount / 100;

            totalPrice = pricePerDay * days * multiply;
            totalPrice -= totalPrice * discountMultiply;

            return totalPrice;
        }
    }
}
