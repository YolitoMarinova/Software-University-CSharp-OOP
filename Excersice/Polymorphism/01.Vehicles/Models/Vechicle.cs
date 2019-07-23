using System;
using Vehicles.Exceptions;

namespace Vehicles.Models
{
    public abstract class Vechicle
    {
        public Vechicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity { get;  set; }
        public double FuelConsumptionPerKm { get;  set; }

        public virtual string Drive(double distance)
        {
            this.FuelQuantity -= this.FuelConsumptionPerKm * distance;

            return $"{this.GetType().Name} travelled {distance} km";
        }
        public virtual void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
