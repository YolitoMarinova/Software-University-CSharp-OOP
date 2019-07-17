using System;
using _04.PizzaCalories;
using _04.PizzaCalories.Exceptions;

namespace _04.PizzaCalories.Models
{
    public class Dough
    {
        private string flourType;
        private string bakingTech;
        private double grams;
        private double caloriesPerGram = IngredientsCalories.BaseCalories;

        public Dough(string flourType, string bakingTech, double grams)
        {
            this.FlourType = flourType;
            this.BakingTech = bakingTech;
            this.Grams = grams;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (!IsValidFlourType(value))
                {
                    throw new ArgumentException(ExceptionsMessages.InvalidDoughTypeException);
                }

                caloriesPerGram *= value == "White"
                    ? IngredientsCalories.WhiteFlour
                    : IngredientsCalories.WholegrainFlour;

                this.flourType = value;
            }
        }
        public string BakingTech
        {
            get
            {
                return this.bakingTech;
            }
            private set
            {
                if (!IsValidBakingTech(value))
                {
                    throw new ArgumentException(ExceptionsMessages.InvalidDoughTypeException);
                }
                string valueToLower = value.ToLower();

                caloriesPerGram *= valueToLower == "crispy" ? IngredientsCalories.Crispy
                    : valueToLower == "chewy" ? IngredientsCalories.Chewy
                    : IngredientsCalories.Homemade;

                this.bakingTech = value;
            }
        }
        public double Grams
        {
            get
            {
                return this.grams;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(ExceptionsMessages.InvalidDouhtWeightException);
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

        private bool IsValidFlourType(string flourType)
        {
            return flourType.ToLower() == "white"
                || flourType.ToLower() == "wholegrain";
        }
        private bool IsValidBakingTech(string bakingTech)
        {
            return bakingTech.ToLower() == "crispy"
                || bakingTech.ToLower() == "chewy"
                || bakingTech.ToLower() == "homemade";
        }
    }
}
