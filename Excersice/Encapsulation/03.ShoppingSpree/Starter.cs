using _03.ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Starter
    {
        public void Start()
        {
            List<Person> people = new List<Person>();

            string[] peopleInput = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var personInfo in peopleInput)
            {
                string[] personNameAndMoney = personInfo.Split("=");

                string name = personNameAndMoney[0];
                decimal money = decimal.Parse(personNameAndMoney[1]);

                try
                {
                    Person person = new Person(name, money);

                    people.Add(person);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            List<Product> products = new List<Product>();

            string[] productsInput = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var productInfo in productsInput)
            {
                string[] productNameAndCost = productInfo.Split("=");

                string name = productNameAndCost[0];
                decimal cost = decimal.Parse(productNameAndCost[1]);

                try
                {
                    Product product = new Product(name, cost);

                    products.Add(product);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            string[] command = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);

            while (command[0]!="END")
            {
                string personName = command[0];
                string productToBuy = command[1];

                Person person = people.FirstOrDefault(n=>n.Name==personName);
                int personIndex = people.FindIndex(x=>x.Name==personName);
                Product product = products.FirstOrDefault(n=>n.Name==productToBuy);

                person.AddProduct(product);
                people[personIndex] = person;

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
