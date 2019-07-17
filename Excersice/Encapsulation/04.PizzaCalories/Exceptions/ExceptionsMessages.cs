using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories.Exceptions
{
    public static class ExceptionsMessages
    {
        public static string InvalidDoughTypeException =
            "Invalid type of dough.";

        public static string InvalidDouhtWeightException =
            "Dough weight should be in the range [1..200].";

        public static string IvalidToppingException =
            "Cannot place {0} on top of your pizza.";

        public static string InvalidToppingWeightException =
            "{0} weight should be in the range [1..50].";

        public static string InvalidToppingCountException =
            "Number of toppings should be in range [0..10].";

        public static string InvalidPizzaNameException =
            "Pizza name should be between 1 and 15 symbols.";
    }
}
