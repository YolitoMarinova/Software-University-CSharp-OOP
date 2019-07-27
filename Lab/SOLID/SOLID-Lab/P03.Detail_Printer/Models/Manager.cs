using System;
using System.Collections.Generic;
using P03.Detail_Printer.Contracts;

namespace P03.DetailPrinter.Models
{
    public class Manager : IEmployee
    {
        public Manager(string name, ICollection<string> documents)
        {
            this.Name = name;
            this.Documents = new List<string>(documents);
        }

        public string Name { get; private set; }
        public IReadOnlyCollection<string> Documents { get; set; }

        public override string ToString()
        {
            return this.Name
                + Environment.NewLine
                + string.Join(Environment.NewLine, this.Documents);
        }
    }
}
