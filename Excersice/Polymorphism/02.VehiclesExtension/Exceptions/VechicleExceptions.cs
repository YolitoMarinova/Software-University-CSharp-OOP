namespace Vehicles.Exceptions
{
    public class VehiclesExceptions 
    {
        public static string InsufficientFuel 
            = "{0} needs refueling";

        public static string NotEnoughTankSpace
            = "Cannot fit {0} fuel in the tank";

        public static string InvalidFuel
            = "Fuel must be a positive number";
    }
}
