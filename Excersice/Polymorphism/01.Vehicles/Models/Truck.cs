using System;
using Vehicles.Exceptions;

namespace Vehicles.Models
{
    public class Truck : Vechicle
    {
        private const double AIR_CONDITIONER_CONSUMPTION = 1.6;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm)
            : base(fuelQuantity, fuelConsumptionPerKm)
        {
        }

        public override string Drive(double distance)
        {
            double airConditionerFuelNeeded = AIR_CONDITIONER_CONSUMPTION * distance;
            bool isEnoughFuel = this.FuelQuantity - (this.FuelConsumptionPerKm * distance) - airConditionerFuelNeeded >= 0;

            if (!isEnoughFuel)
            {
                throw new ArgumentException(string.Format(VehiclesExceptions.InsufficientFuel
                    , this.GetType().Name));
            }
            this.FuelQuantity -= AIR_CONDITIONER_CONSUMPTION * distance;

            return base.Drive(distance);
        }

        public override void Refuel(double fuel)
        {
            fuel = fuel * 0.95;

            base.Refuel(fuel);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
