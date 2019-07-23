using System;
using Vehicles.Exceptions;

namespace Vehicles.Models
{
    public class Car : Vechicle
    {
        private const double AIR_CONDITIONER_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumptionPerKm,double tankCapacity) 
            : base(fuelQuantity, fuelConsumptionPerKm+AIR_CONDITIONER_CONSUMPTION,tankCapacity)
        {
        }

    }
}
