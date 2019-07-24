using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Models.Animal;
using WildFarm.Models.Animal.Birds;
using WildFarm.Models.Animal.Interfaces;
using WildFarm.Models.Animal.Mammal;
using WildFarm.Models.Foods;
using WildFarm.Models.Foods.Factory;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm
{
    public class Engine
    {
        List<Animal> animals = new List<Animal>();
        FoodFactory foodFactory = new FoodFactory();
        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                try
                {
                    IAnimal animal = CreateAnimal(command);
                    IFood food = CreateFood(command);

                    Console.WriteLine(animal.ProduceSound());
                    animal.GiveFood(food);                    
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                command = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private IFood CreateFood(string command)
        {

            string[] foodArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string type = foodArgs[0];
            int quantity = int.Parse(foodArgs[1]);

            IFood food = this.foodFactory.ProduceFood(type, quantity);

            return food;
        }

        private Animal CreateAnimal(string command)
        {
            string[] animalArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            string animalType = animalArgs[0];
            string name = animalArgs[1];
            double weight = double.Parse(animalArgs[2]);
            
            Animal animal=null;

            if (animalType == "Hen")
            {
                double wingSize = double.Parse(animalArgs[3]);

                animal = new Hen(name, weight, wingSize);                
            }
            else if (animalType == "Owl")
            {
                double wingSize = double.Parse(animalArgs[3]);

               animal = new Owl(name, weight, wingSize);
            }
            else if (animalType == "Mouse")
            {
                string livingRegion = animalArgs[3];

                animal = new Mouse(name, weight, livingRegion);
            }
            else if (animalType == "Dog")
            {
                string livingRegion = animalArgs[3];

                animal = new Dog(name, weight, livingRegion);
            }
            else if (animalType == "Cat")
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];

                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (animalType == "Tiger")
            {
                string livingRegion = animalArgs[3];
                string breed = animalArgs[4];

                animal = new Tiger(name, weight, livingRegion, breed);
            }

            this.animals.Add(animal);

            return animal;
        }

    }
}
