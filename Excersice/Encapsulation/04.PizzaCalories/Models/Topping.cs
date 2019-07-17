using _04.PizzaCalories.Exceptions;
using System;


namespace _04.PizzaCalories.Models
{
    public class Topping
    {
        private string type;
        private double grams;
        private double caloriesPerGram = IngredientsCalories.BaseCalories;

        public Topping(string type,double grams)
        {
            this.Type = type;
            this.Grams = grams;
        }

        protected string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                if (!IsValidType(value))
                {
                    throw new ArgumentException
                        (String.Format(ExceptionsMessages.IvalidToppingException, value));
                }

                string valueToLower = value.ToLower();

                caloriesPerGram *= valueToLower == "meat"
                    ? IngredientsCalories.Meat
                    : valueToLower == "veggies"
                    ? IngredientsCalories.Veggies
                    : valueToLower == "cheese"
                    ? IngredientsCalories.Cheese
                    : IngredientsCalories.Sauce;

                this.type = value;
            }
        }
        protected double Grams
        {
            get
            {
                return this.grams;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException
                        (String.Format(ExceptionsMessages.InvalidToppingWeightException, this.Type));
                }

                this.grams = value;
            }
        }
        public double CaloriesPerGram
        {
            get
            {
                return this.caloriesPerGram;
            }
        }

        public double Calories()
        {
            return this.CaloriesPerGram * this.Grams;
        }
        private bool IsValidType(string type)
        {
            return type.ToLower() == "meat"
                || type.ToLower() == "veggies"
                || type.ToLower() == "cheese"
                || type.ToLower() == "sauce";
        }
    }
}
