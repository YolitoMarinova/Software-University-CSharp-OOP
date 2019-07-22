using _09.CollectionHierarchy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy
{
    public class Engine
    {
        public void Run()
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] acOutput = new string[input.Length];
            string[] arcOutput = new string[input.Length];
            string[] myOutput = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                acOutput[i] = addCollection.Add(input[i]).ToString();
                arcOutput[i] = addRemoveCollection.Add(input[i]).ToString();
                myOutput[i] = myList.Add(input[i]).ToString();
            }

            Console.WriteLine(String.Join(" ",acOutput));
            Console.WriteLine(String.Join(" ", arcOutput));
            Console.WriteLine(String.Join(" ", myOutput));

            int countElementsToRemove = int.Parse(Console.ReadLine());

            for (int i = 0; i < countElementsToRemove; i++)
            {
                Console.Write(addRemoveCollection.Remove()+" ");
            }

            Console.WriteLine();

            for (int i = 0; i < countElementsToRemove; i++)
            {
                Console.Write(myList.Remove() + " ");
            }

            Console.WriteLine();
        }
    }
}
