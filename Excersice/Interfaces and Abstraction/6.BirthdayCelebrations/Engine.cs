using _06.BirthdayCelebrations.Interfaces;
using _06.BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;

namespace _06.BirthdayCelebrations
{
    public class Engine
    {
       public readonly List<IBirthdate> birthdates = new List<IBirthdate>();

        public void Run()
        {
            GetRobotsCitizensAndPets();

            string specificYear = Console.ReadLine();

            foreach (var birth in birthdates)
            {
                bool isBornInThatYear = birth.Birthday.EndsWith(specificYear);

                if (isBornInThatYear)
                {
                    Console.WriteLine(birth.Birthday);
                }
            }
        }

        private void GetRobotsCitizensAndPets()
        {
            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                string type = input[0];

                switch (type)
                {
                    case "Citizen":
                        CreateCitizen(input);
                        break;
                    case "Robot":
                        CreateARobot(input);
                        break;
                    case "Pet":
                        CreateAPet(input);
                        break;
                }

                input = Console.ReadLine().Split();
            }
        }

        private void CreateAPet(string[] input)
        {
            string name = input[1];
            string birthday = input[2];

            Pet pet = new Pet(name,birthday);

            this.birthdates.Add(pet);
        }

        private void CreateARobot(string[] input)
        {
            string model = input[1];
            string id = input[2];

            Robot robot = new Robot(model,id);
        }

        private void CreateCitizen(string[] input)
        {
            string name = input[1];
            int age = int.Parse(input[2]);
            string id = input[3];
            string birthday = input[4];

            Citizen citizen = new Citizen(name,age,id,birthday);

            this.birthdates.Add(citizen);
        }
    }
}
