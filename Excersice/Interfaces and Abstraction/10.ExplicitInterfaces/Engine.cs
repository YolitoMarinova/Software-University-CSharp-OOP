using _10.ExplicitInterfaces.Interfaces;
using _10.ExplicitInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _10.ExplicitInterfaces
{
    public class Engine
    {
        public void Run()
        {
            string input = Console.ReadLine();

            while (input!="End")
            {
                string[] citizenArgs = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = citizenArgs[0];
                string country = citizenArgs[1];
                int age = int.Parse(citizenArgs[2]);

                Citizen citizen = new Citizen(name, age, country);

                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());

                input = Console.ReadLine();
            }            
        }
    }
}
