using System;
using System.Collections.Generic;
using WildFarm.Exceptions;
using WildFarm.Models.Animal.Interfaces;
using WildFarm.Models.Foods;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Animal
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }
        protected abstract List<Type> PrefferedFoodTypes { get; }
        protected abstract double WeightMultiplier { get; }

        public abstract string ProduceSound();
        public void GiveFood(IFood food)
        {
            if (!this.PrefferedFoodTypes.Contains(food.GetType()))
            {
                throw new InvalidOperationException
                    (String.Format
                    (ExceptionMessages.InvalidFoodType,
                    this.GetType().Name,
                    food.GetType().Name));
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultiplier;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
