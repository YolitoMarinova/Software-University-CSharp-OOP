using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animal.Mammal
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string bed)
            : base(name, weight, livingRegion, bed)
        {
        }
        protected override List<Type> PrefferedFoodTypes =>
           new List<Type> { typeof(Meat) };

        protected override double WeightMultiplier => 1.00;
        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
