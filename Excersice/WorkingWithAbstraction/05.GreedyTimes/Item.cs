using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GreedyTimes
{
   public class Item
    {
        public Item(string name,long count)
        {
            this.Name = name;
            this.Count = count;
        }

        public string Name { get; set; }
        public long Count { get; set; }

        public override string ToString()
        {
            return $"##{this.Name} - {this.Count}";
        }
    }
}
