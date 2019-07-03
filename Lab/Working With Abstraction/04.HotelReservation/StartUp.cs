using System;

namespace _04.HotelReservation
{
    public class StartUp
    {
        public static void Main()
        {
            string[] vacationInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            decimal pricePerDay = decimal.Parse(vacationInfo[0]);
            int days = int.Parse(vacationInfo[1]);

            Season season = Enum.Parse<Season>(vacationInfo[2]);
            DiscountType discount = new DiscountType();

            if (vacationInfo.Length > 3)
            {
                discount = Enum.Parse<DiscountType>(vacationInfo[3]);
            }

            PriceCalculator vacation = new PriceCalculator(pricePerDay, days, season,discount);


            decimal totalPrice = vacation.CalculatePrice();

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
