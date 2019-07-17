using _04.PizzaCalories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Engine
    {
        public void Run()
        {
            try
            {
                Pizza pizza = CreatePizza();

                Dough dough = CreateDough();

                pizza.Dough = dough;

                string[] toppingInput = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);

                while (toppingInput[0]!="END")
                {
                    string toppingType = toppingInput[1];
                    double toppingGrams = double.Parse(toppingInput[2]);

                    Topping currentTopping=new Topping(toppingType,toppingGrams);

                    pizza.AddTopping(currentTopping);

                    toppingInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private Dough CreateDough()
        {
            string[] doughInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string flourType = doughInput[1];
            string bakingTech = doughInput[2];
            double grams = double.Parse(doughInput[3]);

            return new Dough(flourType,bakingTech,grams);

        }

        private Pizza CreatePizza()
        {
            string[] pizzaInput = Console.ReadLine()
                    .Split(" ");

            string pizzaName = pizzaInput[1];

            return new Pizza(pizzaName);
        }
    }
}
