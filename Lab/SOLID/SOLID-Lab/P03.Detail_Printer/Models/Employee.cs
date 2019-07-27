using P03.Detail_Printer.Contracts;

namespace P03.DetailPrinter.Models
{
    public class Employee : IEmployee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
