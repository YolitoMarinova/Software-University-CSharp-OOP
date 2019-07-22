using _03.Ferrarii.Interfaces;

namespace _03.Ferrarii.Models
{
    public class Ferrari : ICar
    {
        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Model => "488-Spider";

        public string Driver { get; private set; }

        public string UseBrakes()
        {
            return "Brakes!";
        }
        public string PushTheGas()
        {
            return "Gas!";
        }
        public override string ToString()
        {
            return $"{this.Model}/{this.UseBrakes()}/{this.PushTheGas()}/{this.Driver}";
        }
    }
}
