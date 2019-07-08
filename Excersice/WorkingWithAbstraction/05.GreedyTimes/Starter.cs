using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _05.GreedyTimes
{
    public class Starter
    {
        public void Start()
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] itemsInput = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Bag bag = new Bag(capacity);

            for (int i = 0; i < itemsInput.Length; i += 2)
            {
                string name = itemsInput[i];
                long count = long.Parse(itemsInput[i + 1]);

                Item item = new Item(name, count);

                if (bag.IsFull(count))
                {
                    continue;
                }

                if (name.Length == 3)
                {
                    bag.AddCash(item);
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    bag.AddGem(item);
                }
                else if (name.ToLower() == "gold")
                {
                    bag.AddGold(item);
                }
                else
                {
                    continue;
                }                
            }

            Console.WriteLine(bag);
        }
    }
}
