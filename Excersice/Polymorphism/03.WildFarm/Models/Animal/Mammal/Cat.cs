using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animal.Mammal
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string bed)
            : base(name, weight, livingRegion, bed)
        {
        }
        protected override List<Type> PrefferedFoodTypes =>
           new List<Type> { typeof(Vegetable),typeof(Meat) };

        protected override double WeightMultiplier => 0.30;
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
