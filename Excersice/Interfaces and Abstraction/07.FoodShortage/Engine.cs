using _07.FoodShortage.Interfaces;
using _07.FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FoodShortage
{
    public class Engine
    {
        public readonly List<Citizen> citizenBuyers = new List<Citizen>();
        public readonly List<Rebel> rebelBuyers = new List<Rebel>();

        public void Run()
        {
            GetBuyers();

            string name = Console.ReadLine();

            while (name!="End")
            {
                bool isCitizen = this.citizenBuyers.Any(x=>x.Name==name);
                bool isRebel = this.rebelBuyers.Any(x=>x.Name==name);

                if (isCitizen)
                {
                    Citizen citizen = this.citizenBuyers.First(x => x.Name == name);
                    int index = this.citizenBuyers.IndexOf(citizen);

                    this.citizenBuyers[index].BuyFood();
                }
                else if (isRebel)
                {
                    Rebel rebel = this.rebelBuyers.First(x=>x.Name==name);
                    int index = this.rebelBuyers.IndexOf(rebel);

                    this.rebelBuyers[index].BuyFood();
                }

                name = Console.ReadLine();
            }

            int totalFood = this.citizenBuyers.Sum(f => f.Food) 
                + this.rebelBuyers.Sum(f=>f.Food);

            Console.WriteLine(totalFood);
        }

        
        
        private void GetBuyers()
        {
            int buyersCount = int.Parse(Console.ReadLine());

            for (int count = 0; count < buyersCount; count++)
            {
                string[] buyerInfo = Console.ReadLine().Split();

                bool isRebel = buyerInfo.Length == 3;
                bool isCitizen = buyerInfo.Length == 4;

                if (isRebel)
                {
                    CreateRebel(buyerInfo);
                }
                else if (isCitizen)
                {
                    CreateCitizen(buyerInfo);
                }
            }
        }

        private void CreateCitizen(string[] buyerInfo)
        {
            string name = buyerInfo[0];
            int age = int.Parse(buyerInfo[1]);
            string id = buyerInfo[2];
            string birthday = buyerInfo[3];

            Citizen citizen = new Citizen(name,age,id,birthday);

            this.citizenBuyers.Add(citizen);
        }

        private void CreateRebel(string[] buyerInfo)
        {
            string name = buyerInfo[0];
            int age = int.Parse(buyerInfo[1]);
            string group = buyerInfo[2];

            Rebel rebel = new Rebel(name,age,group);

            this.rebelBuyers.Add(rebel);
        }
    }
}
