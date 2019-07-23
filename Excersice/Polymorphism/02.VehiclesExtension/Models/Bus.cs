namespace Vehicles.Models
{
    public class Bus : Vechicle
    {
        private const double AIR_CONDITIONER_CONSUMPTION = 1.4;

        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm+AIR_CONDITIONER_CONSUMPTION, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            this.FuelConsumptionPerKm -= AIR_CONDITIONER_CONSUMPTION;
            return this.Drive(distance);
        }
    }
}
