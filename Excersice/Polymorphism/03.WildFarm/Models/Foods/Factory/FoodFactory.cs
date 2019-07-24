using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Foods.Factory
{
    public class FoodFactory
    {
        public IFood ProduceFood(string type,int quantity)
        {
            IFood food;

            if (type == "Vegetable")
            {
                return food = new Vegetable(quantity);
            }
            else if (type == "Fruit")
            {
                return food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                return food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                return food = new Seeds(quantity);
            }

            return null;
        }
    }
}
