using _07.FoodShortage.Interfaces;

namespace _07.FoodShortage.Models
{
    public class Citizen : IIdentifiable, IBirthdate,IPerson,IBuyer
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;

        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }

        public string Birthday { get; }

        public int Food { get; private set; } = 0;

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
