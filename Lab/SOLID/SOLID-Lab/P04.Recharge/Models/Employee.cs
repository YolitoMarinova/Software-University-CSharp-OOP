using P04.Recharge.Contracts;

namespace P04.Recharge.Models
{
    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {
        }

        public void Sleep()
        {
            // sleep...
        }
    }
}
