using _05.BorderControl.Interfaces;
using _05.BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BorderControl
{
    public class Engine
    {
        public readonly List<IIdentifiable> identifiables = new List<IIdentifiable>();

        public void Run()
        {
            GetRobotsAndCitizens();

            string fakeIdEnd = Console.ReadLine();

            foreach (var item in identifiables)
            {
                if (item.Id.EndsWith(fakeIdEnd))
                {
                    Console.WriteLine(item.Id);
                }
            }
        }

        private void GetRobotsAndCitizens()
        {
            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                if (input.Length == 2)
                {
                    CreateARobot(input);
                }
                else if (input.Length == 3)
                {
                    CreateCitizen(input);
                }

                input = Console.ReadLine().Split();
            }
        }

        private void CreateARobot(string[] input)
        {
            string model = input[0];
            string id = input[1];

            Robot robot = new Robot(model,id);

            this.identifiables.Add(robot);
        }

        private void CreateCitizen(string[] input)
        {
            string name = input[0];
            int age = int.Parse(input[1]);
            string id = input[2];

            Citizen citizen = new Citizen(name,age,id);

            this.identifiables.Add(citizen);
        }
    }
}
