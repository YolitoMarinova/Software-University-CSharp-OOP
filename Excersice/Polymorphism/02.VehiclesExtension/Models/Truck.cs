using System;
using Vehicles.Exceptions;

namespace Vehicles.Models
{
    public class Truck : Vechicle
    {
        private const double AIR_CONDITIONER_CONSUMPTION = 1.6;
        private const double WASTED_FUEL_PERCENT = 5;

        public Truck(double fuelQuantity, double fuelConsumptionPerKm,double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm+AIR_CONDITIONER_CONSUMPTION,tankCapacity)
        {
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);

            double wastedFuel = fuel * (WASTED_FUEL_PERCENT/100);
            this.FuelQuantity -= wastedFuel;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
