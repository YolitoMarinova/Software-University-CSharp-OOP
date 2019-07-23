using Vehicles.Exceptions;
using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main()
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
