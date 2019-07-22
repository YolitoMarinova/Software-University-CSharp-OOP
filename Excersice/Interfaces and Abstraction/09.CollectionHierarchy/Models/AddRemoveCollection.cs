using _09.CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private List<string> list;

        public AddRemoveCollection()
        {
            this.list = new List<string>(100);
        }

        public int Add(string item)
        {
            this.list.Insert(0,item);

            int index = this.list.IndexOf(item);

            return index;
        }

        public string Remove()
        {
            string lastItem = this.list.LastOrDefault();

            this.list.Remove(lastItem);

            return lastItem;
        }
    }
}
