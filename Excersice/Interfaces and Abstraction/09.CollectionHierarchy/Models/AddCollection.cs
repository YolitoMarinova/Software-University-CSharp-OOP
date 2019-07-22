using _09.CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        private List<string> list;

        public AddCollection()
        {
            list = new List<string>(100);
        }

        public int Add(string item)
        {
            this.list.Add(item);

            int index = this.list.LastIndexOf(item);

            return index;
        }
    }
}
