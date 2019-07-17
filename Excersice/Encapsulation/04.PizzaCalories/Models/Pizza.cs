using _04.PizzaCalories.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private double totalCalories
            => CalculateTotalCalories();

        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 1 || value.Length > 15 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionsMessages.InvalidPizzaNameException);
                }

                this.name = value;
            }
        }
        public Dough Dough { get; set; }
        public List<Topping> Toppings { get; private set; }
        public double TotalCalories
        {
            get
            {
                return this.totalCalories;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count > 10)
            {
                throw new ArgumentException(ExceptionsMessages.InvalidToppingCountException);
            }

            this.Toppings.Add(topping);
            CalculateTotalCalories();
        }

        private double CalculateTotalCalories()
        {
            double doughCalories = this.Dough.Calories();
            double allToppingsCalories = this.Toppings.Sum(x => x.Calories());

            return doughCalories + allToppingsCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }
    }
}
