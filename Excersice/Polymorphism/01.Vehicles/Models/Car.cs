using System;
using Vehicles.Exceptions;

namespace Vehicles.Models
{
    public class Car : Vechicle
    {
        private const double AIR_CONDITIONER_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerKm) 
            : base(fuelQuantity, fuelConsumptionPerKm)
        {
        }

        public override string Drive(double distance)
        {
            double airConditionerFuelNeeded = AIR_CONDITIONER_CONSUMPTION * distance;
            bool isEnoughFuel = this.FuelQuantity - (this.FuelConsumptionPerKm * distance)-airConditionerFuelNeeded >= 0;
            
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
            base.Refuel(fuel);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
