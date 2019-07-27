using System.Collections.Generic;
using P03.Detail_Printer.Contracts;

namespace P03.DetailPrinter.Models
{
    public class DetailsPrinter
    {
        private IList<IEmployee> employees;

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (IEmployee employee in this.employees)
            {
                employee.ToString();
            }
        }
    }
}
