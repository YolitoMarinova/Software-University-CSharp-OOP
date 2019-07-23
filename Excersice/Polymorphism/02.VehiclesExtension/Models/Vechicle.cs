using System;
using Vehicles.Exceptions;

namespace Vehicles.Models
{
    public abstract class Vechicle
    {
        private double fuelQuantity;

        public Vechicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public double FuelConsumptionPerKm { get; protected set; }
        public double TankCapacity { get; private set; }

        public virtual string Drive(double distance)
        {
            double neededFuel = this.FuelConsumptionPerKm * distance;

            if (this.FuelQuantity - neededFuel < 0)
            {
                throw new ArgumentException(string.Format(VehiclesExceptions.InsufficientFuel
                    , this.GetType().Name));
            }

            this.FuelQuantity -= neededFuel;

            return $"{this.GetType().Name} travelled {distance} km";
        }
        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException(VehiclesExceptions.InvalidFuel);
            }

            double totalFuel = this.FuelQuantity + fuel;

            if (this.TankCapacity < totalFuel)
            {
                throw new ArgumentException(String.Format(VehiclesExceptions.NotEnoughTankSpace, fuel));
            }

            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
