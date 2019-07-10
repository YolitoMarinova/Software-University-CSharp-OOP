namespace Restaurant.Food
{
    public class Cake
         : Dessert
    {
        private const double DEFAULT_GRAMS = 250;
        private const double DEFAULT_CALORIES = 1000;
        private const decimal DEFAULT_PRICE = 5m;

        public Cake(string name) 
            : base(name, DEFAULT_PRICE, DEFAULT_GRAMS, DEFAULT_CALORIES)
        {
            
        }
    }
}
