using _09.CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        private List<string> list;

        public MyList()
        {
            this.list = new List<string>(100);
        }

        public int Used
            => this.list.Count;

        public int Add(string item)
        {
            this.list.Insert(0, item);

            int index = this.list.IndexOf(item);

            return index;
        }

        public string Remove()
        {
            string firstItem = list.FirstOrDefault();

            this.list.Remove(firstItem);

            return firstItem;
        }
    }
}
