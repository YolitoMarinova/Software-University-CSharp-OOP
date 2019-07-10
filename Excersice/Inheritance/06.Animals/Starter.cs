using System;
using System.Collections.Generic;

namespace Animals
{
    public class Starter
    {
        private List<Animal> animals = new List<Animal>();
        public void Start()
        {        

            string command = Console.ReadLine();

            while (command != "Beast!")
            {
                string[] currentAnimal = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (currentAnimal.Length < 3 && command != "Kitten" && command != "Tomcat")
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }

                string name = currentAnimal[0];
                int age = int.Parse(currentAnimal[1]);
                string gender = String.Empty;

                if (age < 0)
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }

                if (command != "Kitten" && command != "Tomcat")
                {
                    gender = currentAnimal[2];
                }

                AddAnimal(animals, command, name, age, gender);
                

                command = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private void AddAnimal(List<Animal> animals, string command, string name, int age, string gender)
        {
            switch (command)
            {
                case "Dog":
                    Dog dog = new Dog(name, age, gender);
                    animals.Add(dog);
                    break;
                case "Frog":
                    Frog frog = new Frog(name, age, gender);
                    animals.Add(frog);
                    break;
                case "Cat":
                    Cat cat = new Cat(name, age, gender);
                    animals.Add(cat);
                    break;
                case "Kitten":
                    Kitten kitten = new Kitten(name, age);
                    animals.Add(kitten);
                    break;
                case "Tomcat":
                    Tomcat tomcat = new Tomcat(name, age);
                    animals.Add(tomcat);
                    break;
            }
        }
    }
}
