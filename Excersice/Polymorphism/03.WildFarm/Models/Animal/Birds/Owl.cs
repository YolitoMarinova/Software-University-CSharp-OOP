using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animal.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override List<Type> PrefferedFoodTypes =>
            new List<Type> { typeof(Meat)};

        protected override double WeightMultiplier => 0.25;

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
