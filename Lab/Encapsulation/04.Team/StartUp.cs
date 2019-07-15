using System;
using System.Collections.Generic;

namespace PersonsInfo
{
   public class StartUp
    {
       public static void Main()
        {        
            List<Person> allPeople = AddPeople();

            Team team = new Team("SoftUni");

            foreach (var person in allPeople)
            {
                team.AddPlayer(person);
            }
        }

        private static List<Person> AddPeople()
        {
            var list = new List<Person>();

            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstname = personInfo[0];
                string lastName = personInfo[1];
                int age = int.Parse(personInfo[2]);
                decimal salary = decimal.Parse(personInfo[3]);

                Person currentPerson = new Person(firstname, lastName, age, salary);

                list.Add(currentPerson);
            }

            return list;
        }
    }
}
