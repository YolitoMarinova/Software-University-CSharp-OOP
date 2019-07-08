using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.GreedyTimes
{
    public class Bag
    {
        public Bag(long capacity)
        {
            this.Capacity = capacity;
            this.Items = new Dictionary<string, List<Item>>();
            this.Items.Add("Cash", new List<Item>());
            this.Items.Add("Gem", new List<Item>());
            this.Items.Add("Gold", new List<Item>());
        }

        public Dictionary<string, List<Item>> Items { get; set; }
        public long Capacity { get; set; }




        public long Count
        {
            get
            => this.Items["Cash"].Sum(x => x.Count) + this.Items["Gem"].Sum(x => x.Count) + this.Items["Gold"].Sum(x => x.Count);
        }

        public bool IsFull(long countToAdd)
            => this.Capacity < this.Count + countToAdd;

        public void AddCash(Item cashItem)
        {
            if (this.Items["Gem"].Sum(x => x.Count) < this.Items["Cash"].Sum(x => x.Count) + cashItem.Count)
            {
                return;
            }

            this.Items["Cash"].Add(cashItem);
        }

        public void AddGem(Item gemItem)
        {
            if (this.Items["Gold"].Sum(x => x.Count) < this.Items["Gem"].Sum(x => x.Count) + gemItem.Count)
            {
                return;
            }

            this.Items["Gem"].Add(gemItem);
        }

        public void AddGold(Item item)
        {
            if (this.Items["Gold"].Count == 0)
            {
                this.Items["Gold"].Add(new Item("Gold", 0));
            }

            this.Items["Gold"][0].Count += item.Count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            this.Items["Cash"] = this.Sort(this.Items["Cash"]);
            this.Items["Gem"] = this.Sort(this.Items["Gem"]);

            var sortedItems = Items.Where(x => x.Value.Sum(y => y.Count) > 0).OrderByDescending(x => x.Value.Sum(y => y.Count));

            foreach (var (type,items) in sortedItems)
            {
                long countOfItemsFromType = items.Sum(x => x.Count);

                Console.WriteLine($"<{type}> ${countOfItemsFromType}");

                foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }



            return sb.ToString().TrimEnd();
        }

        private List<Item> Sort(List<Item> items)
        {
            return items.OrderByDescending(x => x.Name).ThenBy(x => x.Count).ToList();
        }
    }
}
